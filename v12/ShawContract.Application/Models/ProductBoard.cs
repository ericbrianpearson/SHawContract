using System;
using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class ProductBoard
    {
        public Guid ID { get; set; }
        public string BoardName { get; set; }
        public string Notes { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<ProductBoardItem> ProductBoardItems { get; set; }

        public ProductBoard()
        {
            this.ProductBoardItems = new List<ProductBoardItem>();
        }
    }

    public class ProductBoardItem
    {
        public Guid ID { get; set; }
        public string Style { get; set; }

        public string Color { get; set; }

        public string Notes { get; set; }
    }
}