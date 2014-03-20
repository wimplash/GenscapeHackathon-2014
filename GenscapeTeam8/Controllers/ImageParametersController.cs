using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenscapeTeam8.Controllers
{
    public class ImageParametersController : Controller
    {

        public ActionResult GetImageParameters(int id)
        {
            return View();
        }

        // GET: /ImageParameters/
        public ActionResult Index()
        {
            ViewBag.ImageParametersList = new List<Object>();
            return View();
        }
	}
}