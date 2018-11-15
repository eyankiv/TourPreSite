using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.DAL
{
    public class TourDBContext:DbContext
    {
        public DbSet<Tour1> Tours { get; set; }
        public DbSet<tourCategory1> TourCategories { get; set; }

        public System.Data.Entity.DbSet<ToursSitePreBata.Models.tourClass1> tourClasses { get; set; }

        public System.Data.Entity.DbSet<ToursSitePreBata.Models.tourGallery1> tourGalleries { get; set; }
    }
}