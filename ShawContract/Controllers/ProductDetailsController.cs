using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;

namespace ShawContract.Controllers
{
    public class ProductDetailsController : BaseController
    {
        public ProductDetailsController(IMasterPageService masterPageService)
            : base(masterPageService)
        { }

        // GET: Product Details
        public ActionResult Index(string pageAlias)
        {
            var model = this.GetPageViewModel(pageAlias);

            return View(model);
        }
    }
}