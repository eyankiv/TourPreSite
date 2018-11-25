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
        public DbSet<Tour> Tours { get; set; }
        public DbSet<tourCategory> TourCategories { get; set; }
        public DbSet<tourPhoto> TourPhotos { get; set; }

        public System.Data.Entity.DbSet<ToursSitePreBata.Models.tourClass> tourClasses { get; set; }
        public System.Data.Entity.DbSet<ToursSitePreBata.Models.tourGallery> tourGalleries { get; set; }
    }
}