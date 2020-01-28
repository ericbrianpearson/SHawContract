using AutoMapper;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.BulletListWidget;
using System.Web.Mvc;

[assembly: RegisterWidget(
    "ShawContract.Widget.BulletListWidget",
    typeof(BulletListWidgetController),
    "Bullet List",
    Description = "Bullet List",
    IconClass = "icon-list-bullets")]

namespace ShawContract.Controllers.Widgets
{
    public class BulletListWidgetController : WidgetController<BulletListWidgetProperties>
    {
        private IMapper Mapper { get; }

        public BulletListWidgetController(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        // GET: BulletListWidget
        public ActionResult Index()
        {
            var properties = GetProperties();

            var model = this.Mapper.Map<BulletListWidgetViewModel>(properties);

            return PartialView("Widgets/_BulletListWidget", model);
        }
    }
}