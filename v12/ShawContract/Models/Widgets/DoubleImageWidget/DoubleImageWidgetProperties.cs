using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.DoubleImageWidget
{
    public class DoubleImageWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Small Image URL")]
        public string SmallImage { get; set; }

        public string SmallImagePhotoCredit { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Large Image URL")]
        public string LargeImage { get; set; }

        public string LargeImagePhotoCredit { get; set; }
    }
}