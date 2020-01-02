using Kentico.PageBuilder.Web.Mvc;

namespace ShawContract.Models.Widgets.TwoColumnWidget
{
    public class TwoColumnWidgetProperties : IWidgetProperties
    {
        public string Title { get; set; }
        public string ContentLeft { get; set; }
        public string ContentRight { get; set; }
    }
}