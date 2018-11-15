using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToursSitePreBata.DAL;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ToursDBEntities tourDB = new ToursDBEntities();
            IEnumerable<Tour> tours = tourDB.Tours.ToList();
            return View(tours);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}