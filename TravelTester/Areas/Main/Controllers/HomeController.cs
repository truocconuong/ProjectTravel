using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TravelTester.Models;

namespace TravelTester.Areas.Main.Controllers
{
    public class HomeController : Controller
    {
        private TravelTesterContext db = new TravelTesterContext();

        // GET: Main/Home
        public ActionResult Index()
        {
            var tours = db.Tours.Include("Place").Include("Transporter").Take(3).OrderByDescending(x=>x.Id);
            return View(tours.ToList());
        }
        public ActionResult Places()
        {
            var places = db.Places.Take(3).OrderByDescending(x=> x.Id).ToList();
            return PartialView("~/Areas/Main/Views/Home/Places.cshtml", places);
        }
    }
}