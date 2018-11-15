namespace ToursSitePreBata.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tourGallery")]
    public partial class tourGallery1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tourGallery1()
        {
            Tours = new HashSet<Tour1>();
        }

        [Key]
        public int GalleryID { get; set; }

        [Required]
        [StringLength(50)]
        public string GalleryName { get; set; }

        [StringLength(255)]
        public string GalleryLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour1> Tours { get; set; }
    }
}
