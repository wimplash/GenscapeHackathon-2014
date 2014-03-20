using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AforgeHack
{
    public class HackPictureBox : PictureBox
    {

        public HackPictureBox()
        {
            this.MarkerPoints = new List<MarkerPoint>();
            this.MarkerSize = new Size(40, 40);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (this.MarkerPoints.Count > 0)
            {
               var g = pe.Graphics;
                    foreach (var point in this.MarkerPoints)
                    {
                        g.DrawEllipse(Pens.Blue, new Rectangle((int)(this.Width * point.XRatio) - this.MarkerSize.Width / 2, (int)(this.Height * point.YRatio) - this.MarkerSize.Height / 2, this.MarkerSize.Width, this.MarkerSize.Height));
                    }
            }
        }

        public List<MarkerPoint> MarkerPoints { get; private set; }

        public Size MarkerSize { get; set; }

        

    }

    public class MarkerPoint
    {

        public MarkerPoint(decimal xRatio, decimal yRatio, int frameWidth, int frameHeight)
        {
            this.XRatio = xRatio;
            this.YRatio = yRatio;
            this.Zone = new Rectangle((int)(frameWidth * XRatio) - 20, (int)(frameHeight * yRatio) - 20, 40, 40);
        }
        public decimal XRatio { get; set; }
        public decimal YRatio { get; set; }
        public Rectangle Zone { get; set; }

    }
    
}
