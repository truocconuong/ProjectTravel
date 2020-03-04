using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTester.Areas.Admin.Models;
using TravelTester.Models;

namespace TravelTester.Areas.Admin.Controllers
{

    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
              TravelTesterContext check = new TravelTesterContext();
            return View(check.User.ToList());
        }


        public ActionResult Details(int? id)
        {
            TravelTesterContext check = new TravelTesterContext();
            User user = check.User.Find(id);

            return View(user);
        }
    }
}