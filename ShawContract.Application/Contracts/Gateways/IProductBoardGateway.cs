using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IProductBoardGateway
    {
        IEnumerable<ProductBoard> GetProductBoards(string userId);

        Application.Models.ProductBoard GetProductBoard(Guid boardID);

        Task<Guid> CreateProductBoardAsync(ProductBoard productBoard);

        Task UpdateProductBoardAsync(ProductBoard productBoard);

        Task DeleteProductBoardAsync(Guid productBoardID);

        Task AddProductBoardItemAsync(Guid boardId, ProductBoardItem productBoardItem);

        Task RemoveProductBoardItemAsync(Guid boardId, Guid productId);

        void AddUserToViewersLog(Guid boardId, Application.Models.Visitor visitor);
    }
}