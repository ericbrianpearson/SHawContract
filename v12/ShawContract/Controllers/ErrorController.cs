using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;

namespace ShawContract.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(IMasterPageService masterPageService)
            : base(masterPageService)
        {
        }

        // GET: Error
        public ActionResult ServerError()
        {
            Response.StatusCode = 500;

            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;

            return View();
        }
    }
}