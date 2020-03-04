using ShawContract.ActionSelectors;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Cart;
using ShawContract.Models.Checkout;
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
            var cartModel = CartViewModel.BuildCartViewModel(ShoppingCartService.GetShoppingCartPage());
            var model = GetPageViewModel(cartModel, "Cart");

            return View("Cart", model);
        }

        public ActionResult Products()
        {
            var model = GetPageViewModel("Products");

            return View(model);
        }

        public ActionResult GetSimilarProducts()
        {
            var cart = ShoppingCartService.GetCurrentShoppingCart();
            if (cart.CartItems.Count == 0)
            {
                return new EmptyResult();
            }

            var similarProducts = ShoppingCartService.GetCartSimilarProducts(cart);

            return PartialView("SimilarProducts", new SimilarProductsViewModel(similarProducts));
        }

        [Authorize]
        public ActionResult Checkout()
        {
            return RedirectToAction("Index", "Checkout");
        }
    }
}