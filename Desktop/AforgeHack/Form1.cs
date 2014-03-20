using AForge.Video.DirectShow;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private FilterInfoCollection availableDevices;
        private IVideoSource selectedDevice;

        private void Form1_Load(object sender, EventArgs e)
        {


            using (var db = new AForgeHack.Database.HackEntities())
            {
                //var fac = db.Facilities.First();
                //fac.Cameras.Add(new Camera() { Name = "Dell" });
                //db.SaveChanges();

                MessageBox.Show(db.Facilities.ToList().Count.ToString());
                //db.Facilities.Add
            }

            //this.selectedDevice = new MJPEGStream("http://192.168.4.103:8080");
            //this.selectedDevice.NewFrame += selectedDevice_NewFrame;
            //this.selectedDevice.Start();

            availableDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            this.selectedDevice = new VideoCaptureDevice(availableDevices[0].MonikerString);
            this.selectedDevice.NewFrame += selectedDevice_NewFrame;
            this.selectedDevice.Start();
            
            detector = new MotionDetector(new SimpleBackgroundModelingDetector(), highlighter);
        }


        IMotionProcessing highlighter = new MotionBorderHighlighting();

        MotionDetector detector;

        int processCounter = 0;

        void selectedDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            
            var frame = (Bitmap)eventArgs.Frame.Clone();
            this.frameWidth = frame.Width;
            this.frameHeight = frame.Height;

            if (processCounter >= 1 && this.hackPictureBox1.MarkerPoints.Count > 0)
            {
                processCounter = 0;
                Size boxSize = new Size(frame.Width / 20, frame.Height / 15);

                float max = 0;
                for (int i = 0; i < this.hackPictureBox1.MarkerPoints.Count; i++)
                {
                    var point = this.hackPictureBox1.MarkerPoints[i];
                    detector.MotionZones = new Rectangle[] { new Rectangle((int)(frame.Width * point.XRatio), (int)(frame.Height * point.YRatio), boxSize.Width, boxSize.Height) };
                    max = Math.Max(max, detector.ProcessFrame(eventArgs.Frame));

                }

                this.UpdateText(max.ToString());
            }
            //detector.ProcessFrame(frame);
            //if (detector.MotionDetectionAlgorithm.MotionFrame != null)
                this.hackPictureBox1.Image = frame;//detector.MotionDetectionAlgorithm.MotionFrame.ToManagedImage() ;
            processCounter++;

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
            this.Text = text;
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
            }
        }

        bool marking = false;

        private void button1_Click(object sender, EventArgs e)
        {
            marking = !marking;
            if (marking)
            {
                this.hackPictureBox1.MarkerPoints.Clear();
                this.button1.Text = "Finish Setting Watch Points";
            }
            else
            {
                this.button1.Text = "Set Watch Points";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.selectedDevice.Stop();
        }


    }
}
