using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;

namespace ShawContract.Models.Widgets.FullWidthPhotoWidget
{
    public class FullWidthPhotoWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PhotoCredit { get; set; }

        public string ButtonText { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image Url")]
        public string ImageUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Button URL")]
        public string ButtonUrl { get; set; }

        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Text Box Alignment", Order = 0)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "left; Text Box Left\r\nright; Text Box Right")]
        public string TextBoxAlignment { get; set; } = "left";

        [EditingComponent(CheckBoxComponent.IDENTIFIER, DefaultValue = false, Label = "Full width", Order = 4)]
        public bool IsFullWidth { get; set; }
    }
}