using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Application.Models
{
    public class ShoppingCart
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal TotalItemsPrice { get; set; }
        public decimal TotalDiscount { get; set; }
    }
}