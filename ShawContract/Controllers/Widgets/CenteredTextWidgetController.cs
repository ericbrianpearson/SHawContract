using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.CenteredTextWidget;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.CenteredTextWidget",
    typeof(CenteredTextWidgetController),
    "Centered Text",
    Description = "Centered Text",
    IconClass = "icon-l-text")]

namespace ShawContract.Controllers.Widgets
{
    public class CenteredTextWidgetController : WidgetController<CenteredTextWidgetProperties>
    {
        // GET: CenteredTextWidget
        public ActionResult Index()
        {
            var properties = GetProperties();
            return PartialView("Widgets/_CenteredTextWidget", new CenteredTextWidgetViewModel
            {
                Title = properties.Title,
                Subtitle = properties.Subtitle,
                Description = properties.Description
            });
        }
    }
}