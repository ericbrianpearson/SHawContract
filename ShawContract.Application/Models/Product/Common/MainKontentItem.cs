using System.Collections.Generic;

namespace ShawContract.Application.Models.Product.Common
{
    public class MainKontentItem
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}