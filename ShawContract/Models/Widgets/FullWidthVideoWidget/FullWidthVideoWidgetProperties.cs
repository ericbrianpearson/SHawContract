using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.FullWidthVideoWidget
{
    public class FullWidthVideoWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PhotoCredit { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image Url")]
        public string ImageUrl { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Video Url")]
        public string VideoUrl { get; set; }
    }
}