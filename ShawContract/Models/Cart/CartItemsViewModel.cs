using ShawContract.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShawContract.Models.Cart
{
    public class CartItemsViewModel : IViewModel
    {
        public IEnumerable<int> QuantityDropdown => GetDropDownValues();

        public string ErrorMessage { get; set; }

        public IEnumerable<ShoppingCartItem> CartItems { get; set; }

        public static CartItemsViewModel BuildCartItemsViewModel(ShoppingCart shoppingCart, int quantity = 0)
        {
            return new CartItemsViewModel
            {
                ErrorMessage = ValidateQuantity(quantity),
                CartItems = shoppingCart.CartItems,
            };
        }

        private IEnumerable<int> GetDropDownValues()
        {
            for (int value = 1; value <= 10; value++)
            {
                yield return value;
            }
        }

        private static string ValidateQuantity(int quantity)
        {
            return quantity > 30 ? "Maximum number of samples is 30." : string.Empty;
        }
    }
}