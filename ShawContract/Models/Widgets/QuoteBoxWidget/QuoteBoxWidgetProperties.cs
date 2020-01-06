using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Models.Widgets.QuoteBoxWidget
{
    public class QuoteBoxWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Quote")]
        public string Quote { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Attribution")]
        public string Attribution { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Photo Credit")]
        public string PhotoCredit { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Button Text")]
        public string ButtonText { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Button URL")]
        public string ButtonUrl { get; set; }

        [EditingComponent(RadioButtonsComponent.IDENTIFIER, Order = 5, Label = "Image Alignment")]
        [EditingComponentProperty(nameof(RadioButtonsProperties.DataSource), "right; Image Right\r\nleft; Image Left")]
        public string ImageAlignment { get; set; }

        public Guid ImageGuid { get; set; }
    }
}