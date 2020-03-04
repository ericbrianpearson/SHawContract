using System.Collections.Generic;
using ShawContract.Application.Models.Product;
using ShawContract.Application.Models.Product.Common;

namespace ShawContract.Application.Contracts.Services
{
    public interface IProductsService
    {
        BaseSpecification GetProductPage(string inventoryType, string nodeAlias);

        IEnumerable<CollectionProduct> GetCollectionItems(string collectionName, string inventoryType);

        IEnumerable<CollectionProduct> GetSimilarProducts(IEnumerable<string> items, string inventoryType);
    }
}