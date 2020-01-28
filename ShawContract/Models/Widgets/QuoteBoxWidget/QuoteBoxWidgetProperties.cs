using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;

namespace ShawContract.Models.Widgets.QuoteBoxWidget
{
    public class QuoteBoxWidgetProperties : IWidgetProperties
    {
        public string Quote { get; set; }

        public string Attribution { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image Url")]
        public string ImageUrl { get; set; }

        public string PhotoCredit { get; set; }

        public string ButtonText { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Button URL")]
        public string ButtonUrl { get; set; }

        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Image Alignment", Order = 2)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "left; Image Left\r\nright; Image Right")]
        public string ImageAlignment { get; set; } = "right";
    }
}