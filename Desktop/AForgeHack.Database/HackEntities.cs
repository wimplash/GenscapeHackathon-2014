using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AForgeHack.Database
{
    public class HackEntities : DbContext
    {

        public HackEntities() : base("Hack")
        {

        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<WatchPoint> WatchPoints { get; set; }

    }
}
