using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AForgeHack.Database;

namespace GenscapeTeam8.Controllers
{
    public class CamerasController : Controller
    {
        private HackEntities context = new HackEntities();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.Cameras = context.Cameras.ToList();
            }
            else
            {
                ViewBag.Cameras = context.Cameras.Where(camera => camera.Facility.FacilityID == id).ToList();
            }
            return View();
        }
	}
}