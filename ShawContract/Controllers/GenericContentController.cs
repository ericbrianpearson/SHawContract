using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using System.Web.Mvc;
using System.Web.UI;

namespace ShawContract.Controllers
{
    public class GenericContentController : BaseController
    {
        private IGenericContentPageService GenericContentPageService { get; }

        public GenericContentController(IMasterPageService masterPageService, IGenericContentPageService genericContentPageService) : base(masterPageService)
        {
            this.GenericContentPageService = genericContentPageService;
        }

        // GET: LandingPage
        [OutputCache(Duration = 3600, VaryByParam = "nodeAlias", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string nodeAlias)
        {
            var page = this.GenericContentPageService.GetGenericContentPage(nodeAlias);

            if (page == null)
            {
                return HttpNotFound();
            }
            var model = GetPageViewModel(page.Title);
            HttpContext.Kentico().PageBuilder().Initialize(page.DocumentId);
            return View(model);
        }
    }
}