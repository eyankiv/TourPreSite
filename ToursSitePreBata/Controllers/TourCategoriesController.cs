using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToursSitePreBata.DAL;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.Controllers
{
    public class TourCategoriesController : Controller
    {
        private ToursDBEntities db = new ToursDBEntities();

        // GET: TourCategories
        public ActionResult Index()
        {

            var categories = db.tourCategories.Include(c => c.Tours);
            return View(categories.ToList());
        }

        // GET: TourCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourCategory tourCategory = db.tourCategories.Find(id);
            if (tourCategory == null)
            {
                return HttpNotFound();
            }
            return View(tourCategory);
        }

        // GET: TourCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TourCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CategoryDescription,CategoryPhotoLink")] tourCategory tourCategory)
        {
            if (ModelState.IsValid)
            {
                db.tourCategories.Add(tourCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourCategory);
        }

        // GET: TourCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourCategory tourCategory = db.tourCategories.Find(id);
            if (tourCategory == null)
            {
                return HttpNotFound();
            }
            return View(tourCategory);
        }

        // POST: TourCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryName,CategoryDescription,CategoryPhotoLink")] tourCategory1 tourCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourCategory);
        }

        // GET: TourCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourCategory tourCategory = db.tourCategories.Find(id);
            if (tourCategory == null)
            {
                return HttpNotFound();
            }
            return View(tourCategory);
        }

        // POST: TourCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tourCategory tourCategory = db.tourCategories.Find(id);
            db.tourCategories.Remove(tourCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
