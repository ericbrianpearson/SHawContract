using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using Kentico.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using ShawContract.Models.Home;

namespace ShawContract.Controllers
{
    public class HomeController : BaseController
    {
        private IHomePageService HomePageService { get; }
        public HomeController(IMasterPageService masterPageService, IHomePageService homePageService)
            : base(masterPageService)
        {
            this.HomePageService = homePageService;
        }

        // GET: Home
        public ActionResult Index()
        {

            var page = this.HomePageService.GetHomePage();
            if (page == null)
            {
                return HttpNotFound();
            }
            var model = this.GetPageViewModel(new HomePageViewModel(page), page.Title);

            HttpContext.Kentico().PageBuilder().Initialize(page.DocumentID);
            return View(model);
        }
    }
}