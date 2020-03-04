using ShawContract.Application.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShawContract.Models.Cart
{
    public class CartDropDownViewModel : IViewModel
    {
        public IEnumerable<ShoppingCartItem> CartItems { get; set; }

        public int ItemCount { get; set; }

        public static CartDropDownViewModel BuildCartDropDownViewModel(ShoppingCart shoppingCart)
        {
            return new CartDropDownViewModel
            {
                CartItems = shoppingCart.CartItems.Take(3),
                ItemCount = shoppingCart.CartItems.Count
            };
        }
    }
}