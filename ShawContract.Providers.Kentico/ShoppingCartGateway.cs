using AutoMapper;
using CMS.DocumentEngine.Types.ShawContract;
using CMS.Ecommerce;
using CMS.SiteProvider;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using System;
using System.Linq;

namespace ShawContract.Providers.Kentico
{
    public class ShoppingCartGateway : IShoppingCartGateway
    {
        public IShoppingService ShoppingService;
        public IMapper Mapper;

        public ShoppingCartGateway(IShoppingService shoppingService, IMapper mapper)
        {
            ShoppingService = shoppingService;
            Mapper = mapper;
        }

        public ShoppingCart GetCurrentShoppingCart()
        {
            var shoppingCart = GetShoppingCart();
            var cartPage = GetCartPage();
            shoppingCart.Title = cartPage.Item1;
            shoppingCart.Description = cartPage.Item2;

            return shoppingCart;
        }

        public ShoppingCart GetDropDownShoppingCart()
        {
            var shoppingCart = GetShoppingCart();

            return shoppingCart;
        }

        public void AddItemToCart(int skuId, int quantity)
        {
            ShoppingService.AddItemToCart(skuId, quantity);
        }

        public void RemoveItemFromCart(int id)
        {
            ShoppingService.RemoveItemFromCart(id);
        }

        public void RemoveAllItemsFromCart()
        {
            ShoppingService.RemoveAllItemsFromCart();
        }

        public Tuple<string, string> GetCartPage()
        {
            return CartPageProvider.GetCartPages()
                .LatestVersion(true)
                .OnSite(SiteContext.CurrentSiteName)
                .TopN(1)
                .Select(cp => new Tuple<string, string>(cp.Title, cp.Description))
                .SingleOrDefault();
        }

        public void LoadFakeItemsToCart() //temporary method to load products to cart
        {
            var cartItems = SamplesProvider.GetSamples()
                     .LatestVersion(true)
                     .Published(true)
                     .OnSite(SiteContext.CurrentSiteName)
                     .CombineWithDefaultCulture()
                     .TopN(10)
                     .WhereTrue("SKUEnabled")
                     .OrderByDescending("SKUInStoreFrom")
                     .Select(s => new CartItemSample { Name = s.DocumentName, SKUID = s.SKU.SKUID })
                     .ToList();

            foreach (var item in cartItems)
            {
                ShoppingService.AddItemToCart(item.SKUID, 1);
            }
        }

        private ShoppingCart GetShoppingCart()
        {
            var cart = ShoppingService.GetCurrentShoppingCart();

            return Mapper.Map<ShoppingCartInfo, ShoppingCart>(cart);
        }
    }
}