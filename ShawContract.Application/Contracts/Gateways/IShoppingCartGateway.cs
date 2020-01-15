using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IShoppingCartGateway
    {
        ShoppingCart GetCurrentShoppingCart();

        ShoppingCart GetDropDownShoppingCart();

        void AddItemToCart(int skuId, int quantity);

        void RemoveItemFromCart(int id);

        void RemoveAllItemsFromCart();

        void LoadFakeItemsToCart();
    }
}