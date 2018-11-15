namespace ToursSitePreBata.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tourClass")]
    public partial class tourClass1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tourClass1()
        {
            Tours = new HashSet<Tour1>();
        }

        [Key]
        public int ClassID { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }

        public int ClassPrice { get; set; }

        public int? MaxPassengers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tour1> Tours { get; set; }
    }
}
