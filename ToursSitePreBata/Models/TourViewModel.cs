using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToursSitePreBata.Models
{
    public class TourViewModel
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string TourDescription { get; set; }
        public Nullable<int> PhotoID { get; set; }

        public virtual tourCategory tourCategory { get; set; }
        public virtual TourPhotoMapping TourPhotoMapping { get; set; }

        public SelectList CategoryList { get; set; }
        public List<SelectList> PhotoLists { get; set; }
        public string[] TourPhotos { get; set; }

    }
}