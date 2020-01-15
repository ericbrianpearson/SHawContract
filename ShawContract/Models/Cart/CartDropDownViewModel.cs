using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShawContract.Models.Cart
{
    public class CartDropDownViewModel : IViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }

        public int ItemCount { get; set; }

        public static CartDropDownViewModel BuildCartDropDownViewModel(ShoppingCart shoppingCart)
        {
            return new CartDropDownViewModel
            {
                CartItems = shoppingCart.CartItems.Take(3)
                .Select(item => new CartItem
                {
                    ItemId = item.CartItemID,
                    ItemName = item.CartItemName,
                    Color = item.Color,
                    Quantity = item.TotalUnits
                }),
                ItemCount = shoppingCart.CartItems.Count
            };
        }
    }
}