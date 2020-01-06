using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FullWidthCTAWidget;

[assembly: RegisterWidget("ShawContract.Widget.FullWidthCTAWidget",
    typeof(FullWidthCTAWidgetController),
    "Full Width CTA",
    Description = "Full Width CTA",
    IconClass = "icon-ribbon")]

namespace ShawContract.Controllers.Widgets
{
    public class FullWidthCTAWidgetController : WidgetController<FullWidthCTAWidgetProperties>
    {
        // GET: FullWidthCTAWidget
        public ActionResult Index()
        {
            var properties = GetProperties();
            return PartialView("Widgets/_FullWidthCTAWidget", new FullWidthCTAWidgetViewModel
            {
                Title = properties.Title,
                Description = properties.Description,
                ButtonText = properties.ButtonLinkText,
                ButtonUrl = properties.ButtonLinkUrl
            });
        }
    }
}