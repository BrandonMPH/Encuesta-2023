using Encuestas.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Encuestas.Controllers
{
    
    public class HomeController : Controller
    {
        [Session]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SesionExists(string k)
        {
            ViewBag.UrlDestino = k;
            return PartialView("_sessionexists");
        }
    }
}