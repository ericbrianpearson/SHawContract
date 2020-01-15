using System.Web.Mvc;
using ShawContract.ActionSelectors;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Cart;

namespace ShawContract.Controllers
{
    public class CartDropDownController : BaseController
    {
        public IShoppingCartService ShoppingCartService { get; set; }

        public CartDropDownController(IMasterPageService masterPageService, IShoppingCartService shoppingCartService) : base(masterPageService)
        {
            ShoppingCartService = shoppingCartService;
        }

        // GET: CartDropDown
        public ActionResult Cart()
        {
            var cartModel = GetCartViewModel();

            return PartialView("~/Views/Cart/_CartDropDown.cshtml", cartModel);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult RemoveFromCartDropDown(int removeItemDropDown)
        {
            ShoppingCartService.RemoveItemFromCart(removeItemDropDown);

            var cartModel = GetCartViewModel();

            return PartialView("~/Views/Cart/_CartDropDown.cshtml", cartModel);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult Checkout()
        {
            var cartModel = GetCartViewModel();

            return PartialView("~/Views/Cart/_CartDropDown.cshtml", cartModel);
        }

        private CartDropDownViewModel GetCartViewModel()
        {
            var cart = ShoppingCartService.GetDropDownShoppingCart();
            var cartModel = CartDropDownViewModel.BuildCartDropDownViewModel(cart);

            return cartModel;
        }
    }
}