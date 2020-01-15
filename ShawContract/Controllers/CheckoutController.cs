using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;

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