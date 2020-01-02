using ShawContract.Models.Widgets.FullWidthVideoWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.Widgets.FullWidthPhotoWidget
{
    public class FullWidthPhotoViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoCredit { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public bool HasImage { get; set; }
        public string TextBoxAlignment { get; set; }
        public string ImageUrl { get; set; }
        public MediaLibraryViewModel MediaLibraryViewModel { get; set; }
    }
}