using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FullWidthVideoWidget;
using ShawContract.Models.Widgets.QuoteBoxWidget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.QuoteBoxWidget",
    typeof(QuoteBoxWidgetController),
    "Quote Box Widget",
    Description = "Quote Box Widget",
    IconClass = "icon-newspaper")]

namespace ShawContract.Controllers.Widgets
{
    public class QuoteBoxWidgetController : WidgetController<QuoteBoxWidgetProperties>
    {
        // GET: QuoteBoxWidget
        public ActionResult Index()
        {
            var properties = GetProperties();

            return PartialView("Widgets/_QuoteBoxWidget", new QuoteBoxWidgetViewModel
            {
                Quote = properties.Quote,
                Attribution = properties.Attribution,
                PhotoCredit = properties.PhotoCredit,
                ImageUrl = properties.ImageUrl,
                ButtonText = properties.ButtonText,
                ButtonUrl = properties.ButtonUrl,
                ImageAlignment = properties.ImageAlignment,
            });
        }
    }
}