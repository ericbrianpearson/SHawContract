using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Services
{
    public interface IProductBoardService
    {
        IEnumerable<ProductBoard> GetProductBoards(string userId);

        ProductBoard GetProductBoard(Guid boardID);

        Task<Guid> CreateProductBoardAsync(ProductBoard productBoardName);

        Task UpdateProductBoardAsync(ProductBoard productBoard);

        Task DeleteProductBoardAsync(Guid productBoardID);

        Task AddProductBoardItemAsync(Guid boardId, ProductBoardItem productBoardItem);

        Task RemoveProductBoardItemAsync(Guid boardId, Guid productId);
        void AddVisitorToLog(Guid boardId, Visitor visitor);
    }
}
