using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.SingleFloatingImageWidget
{
    public class SingleFloatingImageWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string WindowTitle { get; set; }
        public string Description { get; set; }
        public string PhotoCredit { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image URL")]
        public string ImageUrl { get; set; }
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Image alignment", Order = 1)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "right; Right\r\nleft; Left")]
        public string ImageAlignment { get; set; } = "right";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Button Text")]
        public string ButtonText { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Button URL")]
        public string ButtonUrl { get; set; }
    }
}