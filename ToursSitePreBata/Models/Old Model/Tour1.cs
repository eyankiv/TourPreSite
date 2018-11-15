namespace ToursSitePreBata.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tour1
    {
        public int TourID { get; set; }

        [Required]
        [StringLength(50)]
        public string TourName { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(100)]
        public string MainPhotoLink { get; set; }

        [Column(TypeName = "text")]
        public string TourDescription { get; set; }

        public int? GalleryId { get; set; }

        public int? ClassID { get; set; }

        public int? LanguageId { get; set; }

        public int? AvailDatesID { get; set; }

        public virtual tourCategory1 tourCategory { get; set; }

        public virtual tourClass1 tourClass { get; set; }

        public virtual tourGallery1 tourGallery { get; set; }
    }
}
