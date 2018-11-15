using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToursSitePreBata.Models
{
    public class Photo1
    {
        [Key][Required]
        public int PhotoId { get; set; }

        [Required][StringLength(50)]
        public string Name { get; set; }

        public int? TourId { get; set; }

        
        public int? GalleryID { get; set; }
    }
}