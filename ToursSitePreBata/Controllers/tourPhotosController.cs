using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.Controllers
{
    public class tourPhotosController : Controller
    {
        private ToursDBEntities db = new ToursDBEntities();

        // GET: tourPhotos
        public ActionResult Index()
        {
            var tourPhotoes = db.tourPhotos.Include(t => t.tourGallery);
            return View(tourPhotoes.ToList());
        }

        // GET: tourPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourPhoto tourPhoto = db.tourPhotos.Find(id);
            if (tourPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tourPhoto);
        }

        // GET: tourPhotos/Create
        //public ActionResult Create()
        //{
        //    ViewBag.GalleryID = new SelectList(db.tourGalleries, "GalleryID", "GalleryName");
        //    return View();
        //}

        // POST: tourPhotos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                //check if file is valid
                if (ValidateFile(file))
                {
                    try
                    {
                        SaveFileToDisk(file);
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("FileName", "Sorry an error occured saving the file to the disk" +
                            ", please try again");
                    }
                }
                else
                {
                    //if the user has not entered a file return an error message
                    ModelState.AddModelError("FileName", "The file must be a gif,png,jpeg or jpg and less than 2MB in size");
                }
            }
            else
            {
                //if the user has not entered a file return an error message
                ModelState.AddModelError("FileName", "Please choose a file");
            }
            if (ModelState.IsValid)
            {
                db.tourPhotos.Add(new tourPhoto { FileName = file.FileName });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: tourPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourPhoto tourPhoto = db.tourPhotos.Find(id);
            if (tourPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryID = new SelectList(db.tourGalleries, "GalleryID", "GalleryName", tourPhoto.GalleryID);
            return View(tourPhoto);
        }

        // POST: tourPhotos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID,FileName,GalleryID")] tourPhoto tourPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryID = new SelectList(db.tourGalleries, "GalleryID", "GalleryName", tourPhoto.GalleryID);
            return View(tourPhoto);
        }

        // GET: tourPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourPhoto tourPhoto = db.tourPhotos.Find(id);
            if (tourPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tourPhoto);
        }

        // POST: tourPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tourPhoto tourPhoto = db.tourPhotos.Find(id);
            db.tourPhotos.Remove(tourPhoto);
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

        private bool ValidateFile(HttpPostedFileBase file)
        {
            string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };
            if ((file.ContentLength > 0 && file.ContentLength < 2097182) && allowedFileTypes.Contains(fileExtension))
            {
                return true;
            }
            return false;
        }

        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            FileInfo info = new FileInfo(file.FileName);
            string fileNameWithoutPath = info.Name;
            if(img.Width > 190)
            {
                img.Resize(190, img.Height);
            }
            //Save full size file
            var path = Path.Combine(LocalResources.Constants.TourImagePath, fileNameWithoutPath);
            try
            {
                img.Save(path);
            }
            catch (Exception)
            {
                ModelState.AddModelError("path","full size imaged not saved due to error");
                Debug.WriteLine(fileNameWithoutPath + " not saved in regular size");
            }
            Debug.WriteLine("combined path is : " + Path.Combine(LocalResources.Constants.TourImagePath, fileNameWithoutPath));
            if(img.Width > 100)
            {
                img.Resize(100, img.Height);
            }
            //save thumbnail
            var thumPath = Path.Combine(LocalResources.Constants.TourThumbnailPath, fileNameWithoutPath);
            try
            {
                img.Save(thumPath);
            }
            catch (Exception)
            {

                ModelState.AddModelError("path", "thumbnail imaged not saved due to error");
                Debug.WriteLine(fileNameWithoutPath + " not saved in regular size");
            }
            Debug.WriteLine("combined path is : " + Path.Combine(LocalResources.Constants.TourThumbnailPath, fileNameWithoutPath));
            
        }
    }
}
