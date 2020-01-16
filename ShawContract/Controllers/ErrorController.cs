using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Errors;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(IMasterPageService masterPageService)
            : base(masterPageService)
        {
        }

        // GET: Error
        public ActionResult ServerError(string error, string innerError)
        {
            var errorModel = new ErrorPageViewModel()
            {
                ErrorCode = Response.StatusCode,
                ErrorMessage = error,
                InnerErrorMessage = innerError
            };
            var model = GetPageViewModel(errorModel, "Error");

            return View("ServerError", "_ErrorLayout", model);
        }
    }
}