using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.FullWidthCTAWidget
{
    public class FullWidthCTAWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Button Link Url")]
        public string ButtonLinkUrl { get; set; }

        public string ButtonLinkText { get; set; }
    }
}