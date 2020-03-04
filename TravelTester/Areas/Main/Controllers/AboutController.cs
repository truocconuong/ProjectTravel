using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelTester.Areas.Main.Controllers
{
    public class AboutController : Controller
    {
        // GET: Main/About
        public ActionResult Index()
        {
            return View();
        }
    }
}