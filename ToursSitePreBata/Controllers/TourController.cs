using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.Controllers
{
    public class TourController : Controller
    {
        private ToursDBEntities dbContext = new ToursDBEntities();
        // GET: Tour
        public ActionResult Index(String category, String search)
        {

            IEnumerable<Tour> tours = dbContext.Tours;
            IEnumerable<string> categories = tours.OrderBy(t => t.tourCategory.CategoryName).Select(t => t.tourCategory.CategoryName).Distinct();
            //ViewBag.category = categories;
            ViewBag.category = new SelectList(categories);
            if (!String.IsNullOrEmpty(category))
            {
                tours = tours.Where(t => t.tourCategory.CategoryName == category);
            }

           
            return View(tours.ToList());
        }
        
        //Get: Tours/Create
        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<Tour> tours = dbContext.Tours;
            IEnumerable<string> categories = tours.OrderBy(t => t.tourCategory.CategoryName)
                .Select(t => t.tourCategory.CategoryName).Distinct();
            //ViewBag.category = categories;
            ViewBag.category = new SelectList(categories);


            return View();
        }

        //Post: Tours/Create
        [HttpPost]
        public ActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                dbContext.Tours.Add(tour);
                dbContext.SaveChanges();
                return RedirectToAction("index");
            }

            return View(tour);
        }
    }
}