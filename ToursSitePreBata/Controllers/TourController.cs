using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToursSitePreBata.DAL;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.Controllers
{
    public class TourController : Controller
    {
        private ToursDBEntities dbContext = new ToursDBEntities();
        // GET: Tour
        public ActionResult Index(string category)
        {
            IEnumerable<tourCategory> categories = dbContext.tourCategories.ToList();
            IEnumerable<Tour> tours = dbContext.Tours.ToList();
            ViewBag.categories = categories;
            //if (categoryId!=0)
            //{
            //    tours = tours.Where(t => t.CategoryID == categoryId);
            //}
            return View(tours);
        }
    }
}