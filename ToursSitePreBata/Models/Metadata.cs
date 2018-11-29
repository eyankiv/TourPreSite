using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToursSitePreBata.Models
{
    public partial class TourMetadata
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string PhotoID { get; set; }
        public string TourDescription { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<int> AvailDatesID { get; set; }

        public virtual tourCategory tourCategory { get; set; }
    }

    public partial class tourCategoryMetadata
    { 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryPhotoLink { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }

    public partial class tourPhotoMetaData
    {
        public int PhotoID { get; set; }

        [StringLength(100)]
        [Index(IsUnique = true)]
        public string FileName { get; set; }

    }
}