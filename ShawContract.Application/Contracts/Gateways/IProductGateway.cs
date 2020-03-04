using System.Collections.Generic;
using ShawContract.Application.Models.Product;
using ShawContract.Application.Models.Product.Common;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IProductGateway
    {
        BaseSpecification GetProductPage(string inventoryType, string nodeAlias);

        IEnumerable<CollectionProduct> GetCollectionProducts(string collectionName, string inventoryType);

        IEnumerable<CollectionProduct> GetSimilarProducts(IEnumerable<string> items, string inventoryType);
    }
}