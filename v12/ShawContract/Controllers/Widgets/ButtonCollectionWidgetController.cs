using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.ButtonCollectionWidget;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.ButtonCollectionWidget",
    typeof(ButtonCollectionWidgetController),
    "ButtonCollectionWidget",
    Description = "ButtonCollectionWidget",
    IconClass = "icon-l-text")]
namespace ShawContract.Controllers.Widgets
{   
    public class ButtonCollectionWidgetController : WidgetController<ButtonCollectionWidgetProperties>
    {
        // GET: ButtonCollectionWidget
        public ActionResult Index()
        {
            var properties = GetProperties();

            //TODO: use automapper
            return PartialView("Widgets/_ButtonCollectionWidget", new ButtonCollectionWidgetViewModel()
            {
                Title = properties.Title,
                Text = properties.Text,
                Button1Text = properties.Button1Text,
                Button1Url = properties.Button1Url,

                Button2Text = properties.Button2Text,
                Button2Url = properties.Button2Url,

                Button3Text = properties.Button3Text,
                Button3Url = properties.Button3Url,

                Button4Text = properties.Button4Text,
                Button4Url = properties.Button4Url,
            });
        }
    }
}