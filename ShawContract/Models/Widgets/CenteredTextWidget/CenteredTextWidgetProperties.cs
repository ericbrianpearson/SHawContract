using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.CenteredTextWidget
{
    public class CenteredTextWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image Url")]
        public string ImageUrl { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Button Text")]
        public string ButtonText { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Button Url")]
        public string ButtonLink { get; set; }
        
    }
}