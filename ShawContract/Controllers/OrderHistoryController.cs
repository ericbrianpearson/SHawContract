using ShawContract.Application.Contracts.Services;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class OrderHistory : BaseController
    {
        public OrderHistory(IMasterPageService masterPageService)
             : base(masterPageService)
        { }

        // GET: OrderHistory
        public ActionResult Index()
        {
            var model = this.GetPageViewModel("OrderHistory");

            return View(model);
        }
    }
}