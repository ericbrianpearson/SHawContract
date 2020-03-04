using ShawContract.Application.Models.Product;
using System.Collections.Generic;

namespace ShawContract.Models.Cart
{
    public class SimilarProductsViewModel
    {
        public IEnumerable<CollectionProduct> SimilarProducts { get; set; }

        public SimilarProductsViewModel(IEnumerable<CollectionProduct> similarProducts)
        {
            SimilarProducts = similarProducts;
        }
    }
}