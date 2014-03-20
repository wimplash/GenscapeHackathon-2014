using System;
using System.Linq;
using System.Web.Mvc;
using AForgeHack.Database;

namespace GenscapeTeam8.Controllers
{
    public class FacilitiesController : Controller
    {
        private HackEntities context = new HackEntities();

        public ActionResult Index()
        {
            ViewBag.Facilities = context.Facilities.ToList();
            return View();
        }
    }
}