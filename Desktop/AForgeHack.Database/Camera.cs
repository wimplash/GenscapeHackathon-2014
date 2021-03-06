﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AForgeHack.Database
{
    public class Camera
    {
        public Camera()
        {
            this.WatchPoints = new List<WatchPoint>();
        }
        public int CameraID { get; set; }
        public Facility Facility { get; set; }
        public string Name { get; set; }
        public virtual List<WatchPoint> WatchPoints { get; set; }
        public string Moniker { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
