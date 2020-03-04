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

namespace TravelTester.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        private TravelTesterContext db = new TravelTesterContext();

        // GET: Admin/Tours
        public ActionResult Index()
        {
            var tours = db.Tours.Include(t => t.Place).Include(t => t.Transporter);
            return View(tours.ToList());
        }

        // GET: Admin/Tours/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/Tours/Create
        public ActionResult Create()
        {
            ViewBag.Place_Id = new SelectList(db.Places, "Id", "Title");
            ViewBag.Transporter_Id = new SelectList(db.Transporters, "Id", "Title");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Place_Id,Transporter_Id,Titile,Content,Images,Description,Quantity_people,Price,Time_start,Time_end,Duration,Time_departure")] Tours tours)
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

        // GET: Admin/Tours/Edit/5
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

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Place_Id,Transporter_Id,Images,Titile,Description,Quantity_people,Price,Time_start,Time_end,Duration,Time_departure")] Tours tours)
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

        // GET: Admin/Tours/Delete/5
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

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tours tours = db.Tours.Find(id);
            db.Tours.Remove(tours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult AddReviewTour([Bind(Include = "Id,Tour_Id,Name,Email,Content,Created_At")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tour_Id = new SelectList(db.Tours, "Id", "Titile", review.Tour_Id);
            return View(review);
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
