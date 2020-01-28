using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Services
{
    public interface IProductBoardService
    {
        Task<IEnumerable<ProductBoard>> GetProductBoardsAsync(string userId);

        Task<ProductBoard> GetProductBoardAsync(Guid boardID);

        Task<Guid> CreateProductBoardAsync(ProductBoard productBoardName);

        Task UpdateProductBoardAsync(ProductBoard productBoard);

        Task DeleteProductBoardAsync(Guid productBoardID);

        Task AddProductBoardItemAsync(Guid boardId, ProductBoardItem productBoardItem);

        Task RemoveProductBoardItemAsync(Guid boardId, Guid productId);
        Task AddVisitorToLog(Guid boardId, Visitor visitor);
    }
}
