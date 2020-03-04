using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;
using ShawContract.Models.Widgets.SingleFloatingImageWidget;
using ShawContract.Controllers.Widgets;

[assembly: RegisterWidget(
    "ShawContract.Widget.SingleFloatingImage",
    typeof(SingleFloatingImageWidgetController),
    "Single Floating Image",
    Description = "Single Floating Image",
    IconClass = "icon-l-img-2-cols-3")]

namespace ShawContract.Controllers.Widgets
{
    public class SingleFloatingImageWidgetController : WidgetController<SingleFloatingImageWidgetProperties>
    {
        // GET: SingleFloatingImageWidget
        public ActionResult Index()
        {
            var properties = GetProperties();
            //TODO: Add automapper
            return PartialView("Widgets/_SingleFloatingImageWidget", new SingleFloatingImageWidgetViewModel()
            {
                Title = properties.Title,
                Subtitle = properties.Subtitle,
                WindowTitle = properties.WindowTitle,
                Description = properties.Description,
                PhotoCredit = properties.PhotoCredit,
                ImageUrl = properties.ImageUrl,
                ImageAlignment = properties.ImageAlignment,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl
            });
        }
    }
}