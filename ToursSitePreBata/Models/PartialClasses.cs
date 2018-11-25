using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToursSitePreBata.Models
{
    [MetadataType(typeof(TourMetadata))]
    public partial class Tour
    {

    }

    [MetadataType(typeof(tourCategoryMetadata))]
    public partial class tourCategory
    {

    }

    
}