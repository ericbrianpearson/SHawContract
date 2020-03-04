using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Application.Models.Product;

namespace ShawContract.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public IShoppingCartGateway ShoppingCartGateway { get; set; }

        public ShoppingCartService(IShoppingCartGateway shoppingCartGateway)
        {
            ShoppingCartGateway = shoppingCartGateway;
        }

        public ShoppingCart GetCurrentShoppingCart()
        {
            return ShoppingCartGateway.GetCurrentShoppingCart();
        }

        public ShoppingCartPage GetShoppingCartPage()
        {
            return ShoppingCartGateway.GetShoppingCartPage();
        }

        public ShoppingCartPage GetFinalizeSubmitPage()
        {
            return ShoppingCartGateway.GetFinalizeSubmitPage();
        }

        public void AddItemToCart(int variantSkuId, int quantity)
        {
            ShoppingCartGateway.AddItemToCart(variantSkuId, quantity);
        }
        
        public void UpdateItemQuantity(int itemId, int quantity)
        {
            this.ShoppingCartGateway.UpdateItemQuantity(itemId, quantity);
        }

        public void RemoveItemFromCart(int id)
        {
            ShoppingCartGateway.RemoveItemFromCart(id);
        }

        public void RemoveAllFromCart()
        {
            ShoppingCartGateway.RemoveAllItemsFromCart();
        }

        public IEnumerable<CollectionProduct> GetCartSimilarProducts(ShoppingCart cart)
        {
            return ShoppingCartGateway.GetCartSimilarProducts(cart);
        }

        public async Task<IEnumerable<Order>> GetHOrderHistory(int userId)
        {
            return await ShoppingCartGateway.GetOrderHistory(userId);
        }

        public async Task SaveOrder(Order order)
        {
            await ShoppingCartGateway.SaveOrder(order);
        }
    }
}