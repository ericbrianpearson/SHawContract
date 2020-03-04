using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kentico.Membership;
using Microsoft.AspNet.Identity.Owin;
using ShawContract.ActionSelectors;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Models.Checkout;
using ShawContract.Models.Personalization;
using Address = ShawContract.Application.Models.Address;

namespace ShawContract.Controllers
{
    public class CheckoutController : BaseController
    {
        public IShoppingCartService ShoppingCartService { get; set; }
        public ISendOrderService OrderService { get; set; }

        public CheckoutController(IMasterPageService masterPageService, IShoppingCartService shoppingCartService, ISendOrderService orderService)
             : base(masterPageService)
        {
            ShoppingCartService = shoppingCartService;
            OrderService = orderService;
        }

        public async Task<ActionResult> Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("RequestSignIn", "Account", new { provider = "", returnUrl = Url.Action("Index", "Checkout") });
            }
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(User.Identity.Name);

            var finalizePage = ShoppingCartService.GetFinalizeSubmitPage();

            var checkoutViewModel = CheckoutViewModel.BuildCheckoutViewModel(user.ShippingAddressesList, finalizePage.Title, finalizePage.Description);

            var model = GetPageViewModel(checkoutViewModel, "Cart");

            return View(model);
        }

        [HttpPost]
        [ButtonNameAction]
        public async Task<ActionResult> SubmitOrder(FormCollection formCollection)
        {
            var order = await GetOrderInfo(formCollection);

            var number = await OrderService.SendOrder(order);

            ShoppingCartService.RemoveAllFromCart();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<OrderItem> GetOrderItems(string[] quantities)
        {
            var cart = ShoppingCartService.GetCurrentShoppingCart();

            int index = 0;
            foreach (var cartItem in cart.CartItems)
            {
                yield return new OrderItem()
                {
                    SKUID = cartItem.SKUIDColor,
                    StyleNumber = cartItem.ItemNumber,
                    StyleName = cartItem.ItemName,
                    ColorNumber = cartItem.ColorNumber,
                    ColorName = cartItem.ColorName,
                    Quantity = decimal.Parse(quantities[index++])
                };
            }
        }

        private async Task<Address> GetShippingAddress(FormCollection formCollection)
        {
            Address address = new Address();
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(User.Identity.Name);

            if (!string.IsNullOrEmpty(formCollection["existingAddress"]))
            {
                var addressList = user.ShippingAddressesList;
                var selectedAddress = addressList.SingleOrDefault(a => a.StreetLine1 == formCollection["existingAddress"]);

                address.City = selectedAddress.City;
                address.CountryName = selectedAddress.Country;
                address.Zip = selectedAddress.PostalCode;
                address.Line1 = selectedAddress.StreetLine1;
                address.Line2 = selectedAddress.StreetLine2;
                address.StateCode = selectedAddress.State != null ? selectedAddress.State : selectedAddress.Province;
            }
            else
            {
                address.FirstName = formCollection["firstName"];
                address.LastName = formCollection["lastName"];
                //no available company field to assign
                address.Phone = formCollection["phoneNumber"];
                address.CountryName = formCollection["country"];
                address.Zip = formCollection["zipCode"];
                address.Line1 = formCollection["addressLineOne"];
                address.Line2 = formCollection["addressLineTwo"];
                address.City = formCollection["city"];
                address.StateCode = formCollection["state"];
            }

            return address;
        }

        private async Task<Order> GetOrderInfo(FormCollection formCollection)
        {
            KenticoSignInManager<ExtendedUser> kenticoSignInManager = HttpContext.GetOwinContext().Get<KenticoSignInManager<ExtendedUser>>();
            ExtendedUser user = await kenticoSignInManager.UserManager.FindByEmailAsync(User.Identity.Name);

            Order order = new Order
            {
                ShippingAddress = await GetShippingAddress(formCollection),
                ShippingMethod = formCollection["shipping-method"],
                ProjectName = formCollection["projectName"],
                Customer = new Customer
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    CustomerUserId = user.Id,
                    Email = user.Email
                }
            };

            int.TryParse(formCollection["accountNumber"], out int accountNumber);
            order.AccountNumber = accountNumber;

            order.OrderItems = GetOrderItems(formCollection["Quantity"].Split(','));

            return order;
        }
    }
}