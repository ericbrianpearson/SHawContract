using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;

namespace ShawContract.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IMasterPageService masterPageService)
            : base(masterPageService)
        { }

        // GET: Home
        public ActionResult Index(string pageAlias)
        {
            var model = this.GetPageViewModel(pageAlias);

            return View(model);
        }
    }
}