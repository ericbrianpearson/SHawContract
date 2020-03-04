using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;
using ShawContract.Application.Models.Product;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IShoppingCartGateway
    {
        ShoppingCart GetCurrentShoppingCart();

        ShoppingCartPage GetShoppingCartPage();

        ShoppingCartPage GetFinalizeSubmitPage();

        void AddItemToCart(int variantSkuId, int quantity);
        void UpdateItemQuantity(int itemId, int quantity);

        void RemoveItemFromCart(int id);

        void RemoveAllItemsFromCart();

        IEnumerable<CollectionProduct> GetCartSimilarProducts(ShoppingCart cart);

        Task SaveOrder(Order order);

        Task<IEnumerable<Order>> GetOrderHistory(int userId);
    }
}