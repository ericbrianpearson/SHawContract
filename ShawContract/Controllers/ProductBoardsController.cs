using ShawContract.Application.Contracts.Services;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class EditProductBoard : BaseController
    {
        public EditProductBoard(IMasterPageService masterPageService)
             : base(masterPageService)
        { }

        // GET: EditProductBoard
        public ActionResult Index()
        {
            var model = this.GetPageViewModel("EditProductBoard");

            return View(model);
        }
    }
}