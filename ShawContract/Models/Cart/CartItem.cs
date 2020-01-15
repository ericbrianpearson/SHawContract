using System.Collections.Generic;
using System.Web.Mvc;

namespace ShawContract.Models.Cart
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string Color { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<SelectListItem> SampleTypes { get; set; }
    }
}