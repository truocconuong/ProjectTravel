using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelTester.Areas.Admin.Models;
using TravelTester.Models;
using PagedList;

namespace TravelTester.Areas.Main.Controllers
{
    public class ToursController : Controller
    {
        private TravelTesterContext db = new TravelTesterContext();

        // GET: Main/Tours
        public ActionResult Index(string sortOrder, string currentFilter, string searchString,string CheckIn , string Checkout,string Adults, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var tours = db.Tours.Include(t => t.Place).Include(t => t.Transporter);
            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(s => s.Titile.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(CheckIn))
            {
                DateTime oDate = Convert.ToDateTime(CheckIn);
                tours = tours.Where(s => s.Time_start >= oDate);
            }
            if (!String.IsNullOrEmpty(Checkout))
            {
                DateTime oDate = Convert.ToDateTime(Checkout);
                tours = tours.Where(s => s.Time_start >= oDate);
            }
            if (!String.IsNullOrEmpty(Adults))
            {
                tours = tours.Where(s => s.Quantity_people.Contains(Adults));
            }
            tours = tours.OrderBy(s => s.Titile);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(tours.ToPagedList(pageNumber, pageSize));
        }

        // GET: Main/Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            Debug.WriteLine(tours);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }

        // GET: Main/Tours/Create
        public ActionResult Create()
        {
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title");
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title");
            return View();
        }

        // POST: Main/Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Place_Id,Transporter_Id,Titile,Description,Quantity_people,Price,Time_start,Time_end,Duration,Time_departure")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title", tours.Place_Id);
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title", tours.Transporter_Id);
            return View(tours);
        }

        // GET: Main/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title", tours.Place_Id);
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title", tours.Transporter_Id);
            return View(tours);
        }

        // POST: Main/Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Place_Id,Transporter_Id,Titile,Description,Quantity_people,Price,Time_start,Time_end,Duration,Time_departure")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title", tours.Place_Id);
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title", tours.Transporter_Id);
            return View(tours);
        }

        // GET: Main/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }

        // POST: Main/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tours tours = db.Tours.Find(id);
            db.Tours.Remove(tours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddReviewTour()
        {
           
            return PartialView("~/Areas/Main/Views/Tours/AddReviewTour.cshtml");
        }
        [HttpPost]
        public ActionResult AddReviewTour([Bind(Include = "Id,Tour_Id,Name,Email,Content,Created_At")] Review review)
        {

            var result = new Review();
            result.Email = review.Email;
            result.Name = review.Name;
            result.Content = review.Content;
            result.Created_At = DateTime.Now;
            result.Tour_Id = review.Id;
            db.Reviews.Add(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddOrder(int id,[Bind(Include = "Id,FirstName,LastName,Email,Address,City,State,PostCode,CardName,CardNumber,SecurityCode,ExpiraDateMonth,ExpiraDateYear")] User user)
        {
            var CheckEmail = db.User.Any(x => x.Email == user.Email);
            if (!CheckEmail)
            {
                user.CreatedAt = DateTime.Now;
                var createEmail = db.User.Add(user);
                db.SaveChanges();
               var Order = new Order();
                Order.User_Id = createEmail.Id;
                Order.Tours_Id = id;
                Order.Status = 0;
                Order.CreatedAt = DateTime.Now;
                var createOrder = db.Order.Add(Order);
                db.SaveChanges();
            }else
            {
                var getUser = db.User.Where(x => x.Email == user.Email).FirstOrDefault();
                var Order = new Order();
                Order.User_Id = getUser.Id;
                Order.Tours_Id = id;
                Order.Status = 0;
                Order.CreatedAt = DateTime.Now;
                var createOrder = db.Order.Add(Order);
                db.SaveChanges();
            }

            return View("~/Areas/Main/Views/Tours/Thankyou.cshtml");
        }





        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tours tours = db.Tours.Find(id);
            Debug.WriteLine(tours);
            if (tours == null)
            {
                return HttpNotFound();
            }
            return View(tours);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
