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

        public ActionResult Details(int id)
        {
            ViewBag.Facility = context.Facilities.Where(facility => facility.FacilityID == id).DefaultIfEmpty(null).First();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}