using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.Widgets.FullWidthPhotoWidget
{
    public class FullWidthPhotoWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Title")]
        public string Title { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Description")]
        public string Description { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Photo Credit")]
        public string PhotoCredit { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Button Text")]
        public string ButtonText { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "Button URL")]
        public string ButtonUrl { get; set; }

        [EditingComponent(RadioButtonsComponent.IDENTIFIER, Order = 6, Label = "Text Box Alignment")]
        [EditingComponentProperty(nameof(RadioButtonsProperties.DataSource), "right; Text Box Right\r\nleft; Text Box Left")]
        public string TextBoxAlignment { get; set; }

        public Guid ImageGuid { get; set; }
    }
}