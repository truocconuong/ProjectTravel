using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTester.Models;

namespace TravelTester.Areas.Main.Controllers
{
    public class DefaultController : Controller
    {
        private TravelTesterContext db = new TravelTesterContext();

        // GET: Main/Default
        public ActionResult Index()
        {
            var tours = db.Tours.Include("Place").Include("Transporter").Take(3).OrderByDescending(x => x.Id);
            return View("~/Areas/Main/Views/Home/Index.cshtml", tours.ToList());
        }
    }
}