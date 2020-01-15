using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public IShoppingCartGateway ShoppingCartGateway { get; set; }

        public ShoppingCartService(IShoppingCartGateway shoppingCartGateway)
        {
            ShoppingCartGateway = shoppingCartGateway;
        }

        public ShoppingCart GetDropDownShoppingCart()
        {
            return ShoppingCartGateway.GetDropDownShoppingCart();
        }

        public ShoppingCart GetCurrentShoppingCart()
        {
            return ShoppingCartGateway.GetCurrentShoppingCart();
        }

        public void AddItemToCart(int skuId, int quantity)
        {
            ShoppingCartGateway.AddItemToCart(skuId, quantity);
        }

        public void RemoveItemFromCart(int id)
        {
            ShoppingCartGateway.RemoveItemFromCart(id);
        }

        public void RemoveAllFromCart()
        {
            ShoppingCartGateway.RemoveAllItemsFromCart();
        }

        public void LoadFakeCart()
        {
            ShoppingCartGateway.LoadFakeItemsToCart();
        }
    }
}