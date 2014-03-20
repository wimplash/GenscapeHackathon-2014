using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AForgeHack.Database;

namespace GenscapeTeam8.Controllers
{
    public class WatchPointsController : Controller
    {
        private HackEntities context = new HackEntities();

        public ActionResult Add(int id, Double x, Double y)
        {
            ViewBag.WatchPointAdded = true;
            ViewBag.WatchPoints = new List<WatchPoint>();
            return View("Index");
        }

        public ActionResult Add(int id)
        {
            var facility = new Facility();
            var camera = new Camera();
            camera.CameraID = 1234;
            camera.Facility = facility;
            camera.Name = "TEST";
            camera.WatchPoints = new List<WatchPoint>();
            ViewBag.Camera = camera;
            return View();
        }

        public ActionResult Detail(int? id)
        {
            ViewBag.WatchPoint = context.WatchPoints.Where(watchPoint => watchPoint.WatchPointID == id).DefaultIfEmpty(null).FirstOrDefault();
            return View();
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.WatchPoints = context.WatchPoints.ToList();
            }
            else
            {
                ViewBag.WatchPoints = context.WatchPoints.Where(watchPoint => watchPoint.Camera.CameraID == id).ToList();
            }
            return View();
        }
    }
}