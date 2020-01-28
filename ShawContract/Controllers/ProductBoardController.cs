using ShawContract.Application.Contracts.Services;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class ProductBoards : BaseController
    {
        public ProductBoards(IMasterPageService masterPageService)
             : base(masterPageService)
        { }

        // GET: Product Boards
        public ActionResult Index()
        {
            var model = this.GetPageViewModel("ProductBoards");

            return View(model);
        }
    }
}