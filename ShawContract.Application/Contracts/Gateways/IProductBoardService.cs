﻿using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IProductBoardGateway
    {
        Task<IEnumerable<ProductBoard>> GetProductBoardsAsync(string userId);

        Task<Application.Models.ProductBoard> GetProductBoardAsync(Guid boardID);

        Task<Guid> CreateProductBoardAsync(ProductBoard productBoard);

        Task UpdateProductBoardAsync(ProductBoard productBoard);

        Task DeleteProductBoardAsync(Guid productBoardID);

        Task AddProductBoardItemAsync(Guid boardId, ProductBoardItem productBoardItem);

        Task RemoveProductBoardItemAsync(Guid boardId, Guid productId);
    }
}