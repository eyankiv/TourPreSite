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
    
    public partial class Tour
    {
        public int TourID { get; set; }
        public string TourName { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string MainPhotoLink { get; set; }
        public string TourDescription { get; set; }
        public Nullable<int> GalleryId { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public Nullable<int> AvailDatesID { get; set; }
    
        public virtual tourCategory tourCategory { get; set; }
        public virtual tourGallery tourGallery { get; set; }
    }
}