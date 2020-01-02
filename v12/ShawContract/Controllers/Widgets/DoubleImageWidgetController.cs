using System;
using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.DoubleImageWidget;

[assembly: RegisterWidget(
    "ShawContract.Widget.DoubleImageWidget",
    typeof(DoubleImageWidgetController),
    "DoubleImageWidget",
    Description = "DoubleImageWidget",
    IconClass = "icon-pictures")]

namespace ShawContract.Controllers.Widgets
{
    public class DoubleImageWidgetController : WidgetController<DoubleImageWidgetProperties>
    {
        // GET: DoubleImageWidget
        public ActionResult Index()
        {
            var properties = GetProperties();

            var model = new DoubleImageWidgetViewModel
            {
                Title = properties.Title,
                Subtitle = properties.Subtitle,
                Description = properties.Description,
                LargeImagePhotoCredit = properties.LargeImagePhotoCredit,
                SmallImagePhotoCredit = properties.SmallImagePhotoCredit,
                SmallImage = properties.SmallImage,
                LargeImage = properties.LargeImage
            };

            return PartialView("Widgets/_DoubleImageWidget", model);
        }
    }
}