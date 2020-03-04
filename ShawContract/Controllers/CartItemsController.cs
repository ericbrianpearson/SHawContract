using ShawContract.ActionSelectors;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Cart;
using System.Web.Mvc;

namespace ShawContract.Controllers
{
    public class CartItemsController : BaseController
    {
        private IShoppingCartService ShoppingCartService { get; set; }

        private IProductsService ProductsService { get; }

        public CartItemsController(IMasterPageService masterPageService, IShoppingCartService shoppingCartService, IProductsService productsService)
            : base(masterPageService)
        {
            ShoppingCartService = shoppingCartService;
            ProductsService = productsService;
        }

        // GET: CartItems
        public ActionResult Index()
        {
            var cartItemsModel = GetCartViewModel();

            return PartialView("_CartItems", cartItemsModel);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult RemoveFromCart(int removeItemId)
        {
            ShoppingCartService.RemoveItemFromCart(removeItemId);
            var cartItemsModel = GetCartViewModel();

            return PartialView("_CartItems", cartItemsModel);
        }

        [HttpPost]
        [ButtonNameAction]
        public ActionResult RemoveAllFromCart()
        {
            ShoppingCartService.RemoveAllFromCart();
            var cartItemsModel = GetCartViewModel();

            return PartialView("_CartItems", cartItemsModel);
        }

        private CartItemsViewModel GetCartViewModel(int quantity = 0)
        {
            var cart = ShoppingCartService.GetCurrentShoppingCart();
            var cartItemsModel = CartItemsViewModel.BuildCartItemsViewModel(cart, quantity);

            return cartItemsModel;
        }

        public ActionResult UpdateItemQuantity(int itemId, int quantity)
        {
            ShoppingCartService.UpdateItemQuantity(itemId, quantity);
            return new EmptyResult();
           
        }
    }
}