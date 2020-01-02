using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Controllers.Widgets;
using ShawContract.Models.Widgets.BulletListWidget;

[assembly: RegisterWidget(
    "ShawContract.Widget.BulletListWidget",
    typeof(BulletListWidgetController),
    "BulletListWidget",
    Description = "BulletListWidget",
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