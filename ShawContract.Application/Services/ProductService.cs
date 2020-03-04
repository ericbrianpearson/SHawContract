using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models.Product;
using ShawContract.Application.Models.Product.Common;

namespace ShawContract.Application.Services
{
    public class ProductService : IProductsService
    {
        private IProductGateway ProductGateway { get; }

        public ProductService(IProductGateway productGateway)
        {
            this.ProductGateway = productGateway;
        }

        public BaseSpecification GetProductPage(string inventoryType, string nodeAlias)
        {
            return this.ProductGateway.GetProductPage(inventoryType, nodeAlias);           
        }

        public IEnumerable<CollectionProduct> GetCollectionItems(string collectionName, string inventoryType)
        {
            return this.ProductGateway.GetCollectionProducts(collectionName, inventoryType);
        }

        public IEnumerable<CollectionProduct> GetSimilarProducts(IEnumerable<string> items, string inventoryType)
        {
            return this.ProductGateway.GetSimilarProducts(items, inventoryType);
        }
    }
}