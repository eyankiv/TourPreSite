//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToursSitePreBata.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tourPhoto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tourPhoto()
        {
            this.TourPhotoMappings = new HashSet<TourPhotoMapping>();
        }
    
        public int PhotoID { get; set; }
        public string FileName { get; set; }
    
        public virtual tourPhoto tourPhoto1 { get; set; }
        public virtual tourPhoto tourPhoto2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TourPhotoMapping> TourPhotoMappings { get; set; }
    }
}
