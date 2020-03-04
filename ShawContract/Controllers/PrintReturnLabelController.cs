using ShawContract.Application.Contracts.Services;
using ShawContract.Models.PrintReturnLabel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class PrintReturnLabelController : BaseController
    {
        public PrintReturnLabelController(IMasterPageService masterPageService)
       : base(masterPageService)
        { }

        // GET: PrintReturnLabel
        public ActionResult Index()
        {
            var model = GetPageViewModel(new PrintReturnLabelViewModel(), "PrintReturnLabel");

            return View(model);
        }
    }
}