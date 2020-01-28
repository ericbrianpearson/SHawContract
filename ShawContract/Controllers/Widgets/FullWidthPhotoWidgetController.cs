using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FullWidthPhotoWidget;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.FullWidthPhotoWidget",
    typeof(FullWidthPhotoWidgetController),
    "Full Width Photo ",
    Description = "Full Width Photo ",
    IconClass = "icon-picture")]

namespace ShawContract.Controllers.Widgets
{
    public class FullWidthPhotoWidgetController : WidgetController<FullWidthPhotoWidgetProperties>
    {
        // GET: FullWidthPhotoWidget
        public ActionResult Index()
        {
            var properties = GetProperties();

            return PartialView("Widgets/_FullWidthPhotoWidget", new FullWidthPhotoViewModel
            {
                Title = properties.Title,
                Description = properties.Description,
                PhotoCredit = properties.PhotoCredit,
                ImageUrl = properties.ImageUrl,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,
                TextBoxAlignment = properties.TextBoxAlignment
            });
        }
    }
}