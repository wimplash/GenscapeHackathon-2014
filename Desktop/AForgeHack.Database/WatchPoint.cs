using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AForgeHack.Database
{
    public class WatchPoint
    {
        public WatchPoint()
        {
            this.Events = new List<Event>();
        }
        public int WatchPointID { get; set; }
        public Camera Camera { get; set; }
        public string Name { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
