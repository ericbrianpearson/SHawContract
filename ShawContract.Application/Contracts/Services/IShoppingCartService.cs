using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;
using ShawContract.Application.Models.Product;

namespace ShawContract.Application.Contracts.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCurrentShoppingCart();

        ShoppingCartPage GetShoppingCartPage();

        ShoppingCartPage GetFinalizeSubmitPage();

        IEnumerable<CollectionProduct> GetCartSimilarProducts(ShoppingCart cart);

        Task<IEnumerable<Order>> GetHOrderHistory(int userId);

        Task SaveOrder(Order order);

        void AddItemToCart(int variantSkuId, int quantity);
        void UpdateItemQuantity(int itemId, int quantity);

        void RemoveItemFromCart(int id);

        void RemoveAllFromCart();
    }
}