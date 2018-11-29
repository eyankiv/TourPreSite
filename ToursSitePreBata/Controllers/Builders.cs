using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToursSitePreBata.Models;

namespace ToursSitePreBata.Controllers
{
    public class Builders
    {
        public static TourViewModel ConvertTourModelToViewModel(Tour tourModel)
        {

            var viewModel = new TourViewModel
            {
                TourID = tourModel.TourID,
                TourName = tourModel.TourName,
                CategoryID = tourModel.CategoryID,
                TourDescription = tourModel.TourDescription,
                PhotoID = tourModel.PhotoID 
                // photoLists and categoryList and tourPhotos will be populated in the control for now
            };

            return viewModel;
        }

        public static Tour ConvertTourViewModelToModel(TourViewModel tourVM)
        {

            var tourModel = new Tour
            {
                TourID = tourVM.TourID,
                TourName = tourVM.TourName,
                CategoryID = tourVM.CategoryID,
                TourDescription = tourVM.TourDescription,
                PhotoID = tourVM.PhotoID,
                
                // photoLists and categoryList and tourPhotos will be populated in the control for now
            };

            return tourModel;
        }
    }

}
   


  