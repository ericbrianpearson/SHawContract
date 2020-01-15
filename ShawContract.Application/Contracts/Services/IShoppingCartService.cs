using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCurrentShoppingCart();

        ShoppingCart GetDropDownShoppingCart();

        void AddItemToCart(int skuId, int quantity);

        void RemoveItemFromCart(int id);

        void RemoveAllFromCart();

        void LoadFakeCart();
    }
}