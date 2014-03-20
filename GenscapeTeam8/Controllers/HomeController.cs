using AForgeHack.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GenscapeTeam8.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Genscape Team 8";

            return View();
        }

        public ActionResult ChartTest()
        {
            using (var db = new HackEntities())
            {
                return View(db.Cameras.Include(c => c.WatchPoints).Include(c => c.WatchPoints.Select(wp => wp.Events)).First());
            }
        }
    }
}
