using ShawContract.ActionSelectors;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Cart;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class CartController : BaseController
    {
        public IShoppingCartService ShoppingCartService { get; set; }

        public CartController(IMasterPageService masterPageService, IShoppingCartService shoppingCartService) : base(masterPageService)
        {
            ShoppingCartService = shoppingCartService;
        }

        // GET: Cart
        public ActionResult Index()
        {
            ShoppingCartService.LoadFakeCart();
            var cartModel = GetCartViewModel();
            var model = GetPageViewModel(cartModel, "Cart");

            return View("Cart", model);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult RemoveFromCart(int removeItemId)
        {
            ShoppingCartService.RemoveItemFromCart(removeItemId);
            var cartModel = GetCartViewModel();
            var model = GetPageViewModel(cartModel, "Cart");

            return View("Cart", model);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult RemoveAllFromCart()
        {
            ShoppingCartService.RemoveAllFromCart();
            var cartModel = GetCartViewModel();
            var model = GetPageViewModel(cartModel, "Cart");

            return View("Cart", model);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult Checkout(int quantitySum)
        {
            var cartModel = GetCartViewModel(quantitySum);
            var model = GetPageViewModel(cartModel, "Cart");

            return View("Cart", model);
        }

        private CartViewModel GetCartViewModel(int quantity = 0)
        {
            var cart = ShoppingCartService.GetCurrentShoppingCart();
            var cartModel = CartViewModel.BuildCartViewModel(cart, quantity);

            return cartModel;
        }
    }
}