﻿using AForge.Video.DirectShow;
using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Vision.Motion;
using AForge.Imaging;
using AForgeHack.Database;

namespace AforgeHack
{
    public partial class WatchForm : Form
    {

        #region Member Variables 
        
        private Camera camera;
        HackEntities db = new HackEntities();
        private IVideoSource selectedDevice;
        MotionDetector detector = new MotionDetector(new SimpleBackgroundModelingDetector(), new MotionAreaHighlighting(Color.Red));
        int processCounter = 0;
        private Dictionary<WatchPoint, DateTime> releaseReferences = new Dictionary<WatchPoint, DateTime>();

        #endregion

        #region Constructors

        public WatchForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties
        public Camera Camera
        {
            get { return camera; }
            set 
            {
                camera = db.Cameras.Find(value.CameraID);                
                if (!string.IsNullOrWhiteSpace(camera.Moniker))
                {
                    //setup webcam
                    this.selectedDevice = new VideoCaptureDevice(camera.Moniker);
                    this.selectedDevice.NewFrame += selectedDevice_NewFrame;
                    this.selectedDevice.Start();

                    
            
                }
                else if (!string.IsNullOrWhiteSpace(camera.Url))
                {
                    //setup ip cam
                }
                else if (!string.IsNullOrWhiteSpace(camera.Path))
                {
                    //setup file based stuff
                }
            }
        }        

        #endregion

        void selectedDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            
            var frame = (Bitmap)eventArgs.Frame.Clone();
            if (this.frameHeight == 0)
            {
                this.frameWidth = frame.Width;
                this.frameHeight = frame.Height;
                this.LoadWatchPoints();
            }

            if (processCounter >= 3 && this.hackPictureBox1.MarkerPoints.Count > 0)
            {
                processCounter = 0;

                
                for (int i = 0; i < this.camera.WatchPoints.Count; i++)
                {
                    var point = this.camera.WatchPoints[i];
                    detector.MotionZones = new Rectangle[] { new Rectangle(point.Left, point.Top, point.Width, point.Height) };
                    var value = detector.ProcessFrame(frame);                    
                    if (value > .001)
                    {
                        UpdateText(point.Name);
                        if (point.Events.Count == 0 || (DateTime.Now - point.Events.Last().EndTime ).TotalSeconds > 5)
                        {
                            var e = new Event() { StartTime = DateTime.Now, EndTime = DateTime.Now, Notes = "Motion", WatchPoint = point };
                            this.AddEvent(e);
                            point.Events.Add(e);
                            db.SaveChangesAsync();                            
                        }
                        else
                        {
                            point.Events.Last().EndTime = DateTime.Now;
                        }
                        
                    }
                }
            }

            if (this.ImageryCheckBox.Checked)
            {
                detector.MotionZones = null;
                detector.ProcessFrame(frame);
                if (detector.MotionDetectionAlgorithm.MotionFrame != null)
                    this.hackPictureBox1.Image = detector.MotionDetectionAlgorithm.MotionFrame.ToManagedImage();
            }
            else
            {

                if (this.hackPictureBox1.MarkerPoints.Count > 0)
                {
                    this.detector.MotionZones = this.hackPictureBox1.MarkerPoints.Select(mp => mp.Zone).ToArray();
                    detector.ProcessFrame(frame);
                }
                this.hackPictureBox1.Image = frame; //detector.MotionDetectionAlgorithm.MotionFrame.ToManagedImage() ;
            }
            processCounter++;

        }

       public void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer.Stop();
        }

        private int frameWidth;
        private int frameHeight;

        public void UpdateText(string text)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<string>(UpdateText), text);
                }
                catch { }
            }
            else
            {
                this.Text = text;
            }
        }

        public void AddEvent(Event e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action<Event>(AddEvent), e);
                }
                catch { }
            }
            else
            {
                this.EventsListBox.Items.Add(e);
            }
        }


        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (marking)
            {
                lock (this.hackPictureBox1.MarkerPoints)
                {
                    this.hackPictureBox1.MarkerPoints.Add(
                        new MarkerPoint(
                            (decimal)e.X / this.hackPictureBox1.Width, 
                            (decimal)e.Y / this.hackPictureBox1.Height,
                            frameWidth,
                            frameHeight
                            ));
                }
                var watchPoint =new WatchPoint() { 
                    Camera = this.Camera,
                    Name = "Watch Point " + (this.hackPictureBox1.MarkerPoints.Count + 1).ToString(), 
                    Top = (int)((decimal)e.Y / this.hackPictureBox1.Height * frameHeight - 20),
                    Left = (int)((decimal)e.X / this.hackPictureBox1.Width * frameWidth - 20),
                    Width = 40,
                    Height = 40
                };
                this.Camera.WatchPoints.Add(watchPoint);
                db.SaveChangesAsync();
            }
        }

        bool marking = false;

        private void button1_Click(object sender, EventArgs e)
        {
            marking = !marking;
            if (marking)
            {
                this.hackPictureBox1.MarkerPoints.Clear();
                this.watchPointHolder = this.camera.WatchPoints.ToList();
                this.Camera.WatchPoints.Clear();
                db.WatchPoints.RemoveRange(this.Camera.WatchPoints);
                this.button1.Text = "Save Watch Points";
                this.CancelButton.Visible = true;
            }
            else
            {
                db.SaveChangesAsync();
                this.watchPointHolder = null;
                this.CancelButton.Visible = false;
                this.button1.Text = "Set Watch Points";
            }
        }

        IEnumerable<WatchPoint> watchPointHolder;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            

            this.selectedDevice.Stop();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            marking = false;
            foreach(var wp in this.watchPointHolder)
            {
                db.Entry(wp).State = System.Data.Entity.EntityState.Modified;
                this.Camera.WatchPoints.Add(wp);
            }
            db.SaveChangesAsync();
            this.LoadWatchPoints();
            this.CancelButton.Visible = false;
            this.button1.Text = "Set Watch Points";
        }

        private void LoadWatchPoints()
        {
            this.hackPictureBox1.MarkerPoints.Clear();
            foreach (var watchPoint in Camera.WatchPoints)
            {
                this.hackPictureBox1.MarkerPoints.Add(new MarkerPoint((watchPoint.Left + 20) / (decimal)frameWidth, (watchPoint.Top + 20) / (decimal)frameHeight, watchPoint.Width, watchPoint.Height));
                
            }
        }

        private void WatchForm_Load(object sender, EventArgs e)
        {

        }


    }
}