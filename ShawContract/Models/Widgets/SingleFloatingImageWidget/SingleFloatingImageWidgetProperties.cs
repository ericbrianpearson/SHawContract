using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.SingleFloatingImageWidget
{
    public class SingleFloatingImageWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoCredit { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Image URL")]
        public string ImageUrl { get; set; }
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Image alignment", Order = 0)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "right; Right\r\nleft; Left")]
        public string ImageAlignment { get; set; } = "right";
    }
}