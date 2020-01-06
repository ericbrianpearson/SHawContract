using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.CenteredTextWidget
{
    public class CenteredTextWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
    }
}