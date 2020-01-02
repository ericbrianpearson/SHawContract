using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.FeatureListWidget;
using System.Text.RegularExpressions;
using System.Web.Mvc;

[assembly: RegisterWidget("ShawContract.Widget.FeatureListWidget",
    typeof(FeatureListWidgetController),
    "Feature list",
    Description = "Feature list",
    IconClass = "icon-l-header-cols-2-footer")]
namespace ShawContract.Controllers.Widgets
{
    public class FeatureListWidgetController : WidgetController<FeatureListWidgetProperties>
    {
        // GET: FeatureListWidget
        public ActionResult Index()
        {
            var properties = GetProperties();           
            return PartialView("Widgets/_FeatureListWidget", new FeatureListWidgetViewModel()
            {
                Title = properties.Title,
                Subtitle = properties.Subtitle,

                Icon1 = GetIconType(properties.Icon1),
                Description1 = properties.Description1,
                LinkUrl1 = properties.LinkUrl1,
                SecondaryTitle1 = properties.SecondaryTitle1,

                Icon2 = GetIconType(properties.Icon2),
                Description2 = properties.Description2,
                LinkUrl2 = properties.LinkUrl2,
                SecondaryTitle2 = properties.SecondaryTitle2,

                Icon3 = GetIconType(properties.Icon3),
                Description3 = properties.Description3,
                LinkUrl3 = properties.LinkUrl3,
                SecondaryTitle3 = properties.SecondaryTitle3,

                Icon4 = GetIconType(properties.Icon4),
                Description4 = properties.Description4,
                LinkUrl4 = properties.LinkUrl4,
                SecondaryTitle4 = properties.SecondaryTitle4,

                Icon5 = GetIconType(properties.Icon5),
                Description5 = properties.Description5,
                LinkUrl5 = properties.LinkUrl5,
                SecondaryTitle5 = properties.SecondaryTitle5,

                Icon6 = GetIconType(properties.Icon6),
                Description6 = properties.Description6,
                LinkUrl6 = properties.LinkUrl6,
                SecondaryTitle6 = properties.SecondaryTitle6,

            });
        }

        private static string GetIconType(string iconTag)
        {
            if (iconTag != null)
            {
                var regex = new Regex("\"[^\"]*\"");
                var iconType = regex.Matches(iconTag);
                var tag = iconType[0].ToString();
                return iconType[0].ToString().Replace("\"", "");
            }
            else
            {
                return iconTag;
            }
        }
    }
}