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
        public bool LoggedUserRequiredToAccess { get; set; } = false;

        public List<ProductBoardItem> ProductBoardItems { get; set; }
        public List<Visitor> Visitors { get; set; }

        public ProductBoard()
        {
            this.ProductBoardItems = new List<ProductBoardItem>();
        }
    }

    public class ProductBoardItem
    {
        public Guid ID { get; set; }

        public string Notes { get; set; }
        public string StyleName { get; set; }
        public string StyleNumber { get; set; }
        public string ColorName { get; set; }
        public string ColorNumber { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Visitor
    {
        public string Email { get; set; }
        public DateTime DateVisited { get; set; }
    }
}