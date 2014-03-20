using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AForgeHack.Database
{
    public class Facility
    {
        public Facility()
        {
            this.Cameras = new List<Camera>();
        }
        public int FacilityID { get; set; }
        public string Name { get; set; }
        public virtual List<Camera> Cameras { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
