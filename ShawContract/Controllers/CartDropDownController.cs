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
            var cartModel = GetCartDropDownViewModel();

            return PartialView("~/Views/Cart/_CartDropDown.cshtml", cartModel);
        }

        [HttpPost]
        public ActionResult RemoveFromCartDropDown(int removeItemDropDown)
        {
            ShoppingCartService.RemoveItemFromCart(removeItemDropDown);

            var cartModel = GetCartDropDownViewModel();

            return PartialView("~/Views/Cart/_CartDropDown.cshtml", cartModel);
        }


        public ActionResult Checkout()
        {
            return RedirectToAction("Index", "Checkout");
        }

        private CartDropDownViewModel GetCartDropDownViewModel()
        {
            var cart = ShoppingCartService.GetCurrentShoppingCart();
            var cartModel = CartDropDownViewModel.BuildCartDropDownViewModel(cart);

            return cartModel;
        }
    }
}