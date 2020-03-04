using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal TotalItemsPrice { get; set; }
        public decimal TotalDiscount { get; set; }
    }
}