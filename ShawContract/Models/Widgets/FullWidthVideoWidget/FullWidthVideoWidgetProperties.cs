using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.Widgets.FullWidthVideoWidget
{
    public class FullWidthVideoWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Title")]
        public string Title { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Description")]
        public string Description { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Photo Credit")]
        public string PhotoCredit { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Video Url")]
        public string VideoUrl { get; set; }

        public Guid ImageGuid { get; set; }
    }
}