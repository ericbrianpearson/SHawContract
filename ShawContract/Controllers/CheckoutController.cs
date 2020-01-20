using ShawContract.Application.Contracts.Services;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class CheckoutController : BaseController
    {
        public CheckoutController(IMasterPageService masterPageService)
             : base(masterPageService)
        { }

        // GET: Checkout
        public ActionResult Index()
        {
            var model = this.GetPageViewModel("Checkout");

            return View(model);
        }
    }
}