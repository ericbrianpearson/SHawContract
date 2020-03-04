using System.Web;
using System.Web.Mvc;
using Kentico.Membership;
using Microsoft.AspNet.Identity.Owin;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.OrderHistory;
using ShawContract.Models.Personalization;

namespace ShawContract.Controllers
{
    public class OrderHistoryController : BaseController
    {
        public IShoppingCartService ShoppingCartService { get; set; }

        public OrderHistoryController(IMasterPageService masterPageService, IShoppingCartService shoppingCartService)
             : base(masterPageService)
        {
            ShoppingCartService = shoppingCartService;
        }

        [Authorize]
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Orders()
        {
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(User.Identity.Name);

            var orders = await ShoppingCartService.GetHOrderHistory(user.Id);

            var model = this.GetPageViewModel(new OrderViewModel(orders), "OrderHistory");

            return View(model);
        }

        public ActionResult OrderDetails(int orderId)
        {
            var model = this.GetPageViewModel(new OrderViewModel(null), "OrderHistory");

            return View("Orders", model);
        }
    }
}