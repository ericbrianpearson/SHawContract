using ShawContract.Application.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;
using ShawContract.Application.Contracts.Gateways;

namespace ShawContract.Application.Services
{
    public class ProductBoardService : IProductBoardService
    {
        protected IProductBoardGateway ProductBoardGateway { get; }

        public ProductBoardService(IProductBoardGateway productBoardGateway)
        {
            ProductBoardGateway = productBoardGateway;
        }
        public async Task AddProductBoardItemAsync(Guid boardId, ProductBoardItem productBoardItem)
        {
             await ProductBoardGateway.AddProductBoardItemAsync(boardId, productBoardItem);
        }

        public async Task<Guid> CreateProductBoardAsync(ProductBoard productBoard)
        {
            return await ProductBoardGateway.CreateProductBoardAsync(productBoard);
        }

        public async Task DeleteProductBoardAsync(Guid productBoardID)
        {
            await ProductBoardGateway.DeleteProductBoardAsync(productBoardID);
        }

        public  ProductBoard GetProductBoard(Guid boardID)
        {
            return  ProductBoardGateway.GetProductBoard(boardID);
        }

        public IEnumerable<ProductBoard> GetProductBoards(string userId)
        {
            return  ProductBoardGateway.GetProductBoards(userId);
        }

        public async Task RemoveProductBoardItemAsync(Guid boardId, Guid productId)
        {
            await ProductBoardGateway.RemoveProductBoardItemAsync(boardId, productId);
        }

        public async Task UpdateProductBoardAsync(ProductBoard productBoard)
        {
            await ProductBoardGateway.UpdateProductBoardAsync(productBoard);
        }

        public void AddVisitorToLog(Guid boardId, Visitor visitor)
        {
             ProductBoardGateway.AddUserToViewersLog(boardId, visitor);
        }
    }
}
