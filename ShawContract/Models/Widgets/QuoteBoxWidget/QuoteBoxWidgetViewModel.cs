using ShawContract.Models.Widgets.FullWidthVideoWidget;
using ShawContract.Models.Widgets.WidgetShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShawContract.Models.Widgets.QuoteBoxWidget
{
    public class QuoteBoxWidgetViewModel
    {
        public string Quote { get; set; }
        public string Attribution { get; set; }
        public string PhotoCredit { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
        public bool HasImage { get; set; }
        public string ImageAlignment { get; set; }
        public string ImageUrl { get; set; }
        public MediaLibraryViewModel MediaLibraryViewModel { get; set; }
    }
}