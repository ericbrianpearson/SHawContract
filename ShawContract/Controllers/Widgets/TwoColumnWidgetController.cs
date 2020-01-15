using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.TwoColumnWidget;

[assembly: RegisterWidget("ShawContract.Widget.TwoColumnWidget",
    typeof(TwoColumnWidgetController),
    "Two Column Paragraph",
    Description = "Two Column Paragraph",
    IconClass = "icon-l-header-cols-2-footer")]

namespace ShawContract.Controllers.Widgets
{
    public class TwoColumnWidgetController : WidgetController<TwoColumnWidgetProperties>
    {
        // GET: TwoColumnWidget
        public ActionResult Index()
        {
            var properties = GetProperties();
            return PartialView("Widgets/_TwoColumnWidget", new TwoColumnWidgetViewModel
            {
                Title = properties.Title,
                ContentLeft = properties.ContentLeft,
                ContentRight = properties.ContentRight
            });
        }
    }
}