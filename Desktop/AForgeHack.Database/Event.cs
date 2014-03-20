using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AForgeHack.Database
{
    public class Event
    {
        public int EventID { get; set; }
        public WatchPoint WatchPoint { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Notes { get; set; }
        public override string ToString()
        {
            return this.TimeStamp + " " + this.Notes;
        }

    }
}
