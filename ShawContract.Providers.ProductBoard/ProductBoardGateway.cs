using AutoMapper;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Models;
using ShawContract.Providers.ProductBoard.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ShawContract.Providers.ProductBoard
{
    public class ProductBoardGateway : IProductBoardGateway
    {
        private ProductBoardContext ProductBoardContext { get; }
        private IMapper Mapper { get; }

        public ProductBoardGateway(IMapper mapper)
        {
            this.ProductBoardContext = new ProductBoardContext();
            this.Mapper = mapper;
        }

        public async Task<Guid> CreateProductBoardAsync(Application.Models.ProductBoard productBoard)
        {
            var board = this.Mapper.Map<Models.ProductBoard>(productBoard);
            board.ID = Guid.NewGuid();
            board.CreatedOn = DateTime.UtcNow;
            board.ModifiedOn = DateTime.UtcNow;

            foreach (var item in board.ProductBoardItems)
            {
                item.ID = Guid.NewGuid();
                item.CreatedOn = DateTime.UtcNow;
                item.ModifiedOn = DateTime.UtcNow;
            }
            try
            {
                this.ProductBoardContext.ProductBoards.Add(board);
                await this.ProductBoardContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Create Product board failed!", ex);
            }

            return board.ID;
        }

        public async Task<Application.Models.ProductBoard> GetProductBoardAsync(Guid boardID)
        {
            try
            {
                var item = await this.ProductBoardContext.ProductBoards
                .Where(b => b.ID == boardID)
                .Include(b => b.ProductBoardItems)
                .FirstOrDefaultAsync();

                return this.Mapper.Map<Application.Models.ProductBoard>(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Get Product boards failed!", ex);
            }
        }

        public async Task<IEnumerable<Application.Models.ProductBoard>> GetProductBoardsAsync(string userId)
        {
            try
            {
                var items = await this.ProductBoardContext.ProductBoards
                .Where(b => b.UserId == userId)
                .Include(b => b.ProductBoardItems)
                .ToListAsync();

                return this.Mapper.Map<List<Application.Models.ProductBoard>>(items);
            }
            catch (Exception ex)
            {
                throw new Exception("Get Product board by user ID failed!", ex);
            }
        }

        public async Task UpdateProductBoardAsync(Application.Models.ProductBoard productBoard)
        {
            try
            {
                var board = await this.ProductBoardContext.ProductBoards
                    .Where(p => p.ID == productBoard.ID)
                    .FirstOrDefaultAsync();

                board.ModifiedOn = DateTime.UtcNow;
                board.Notes = productBoard.Notes;
                board.BoardName = productBoard.BoardName;

                await this.ProductBoardContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Update Product board failed!", ex);
            }
        }

        public async Task AddProductBoardItemAsync(Guid boardId, ProductBoardItem productBoardItem)
        {
            try
            {
                var productBoard = await this.ProductBoardContext.ProductBoards.FirstOrDefaultAsync(p => p.ID == boardId);
                var productItemToAdd = this.Mapper.Map<Models.ProductBoardItem>(productBoardItem);
                productItemToAdd.ID = Guid.NewGuid();
                productItemToAdd.ModifiedOn = DateTime.UtcNow;
                productItemToAdd.CreatedOn = DateTime.UtcNow;
                productBoard.ProductBoardItems.Add(productItemToAdd);

                await this.ProductBoardContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Add Product board item failed!", ex);
            }
        }

        public async Task RemoveProductBoardItemAsync(Guid boardId, Guid productId)
        {
            try
            {
                var productBoard = await this.ProductBoardContext.ProductBoards.FirstOrDefaultAsync(p => p.ID == boardId);
                var productBoardItem = productBoard.ProductBoardItems.FirstOrDefault(i => i.ID == productId);
                this.ProductBoardContext.ProductBoardItems.Remove(productBoardItem);

                await this.ProductBoardContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Remove Product board item failed!", ex);
            }
        }

        public async Task DeleteProductBoardAsync(Guid productBoardID)
        {
            try
            {
                Models.ProductBoard productBoard = this.ProductBoardContext
                    .ProductBoards
                    .Where(b => b.ID == productBoardID)
                    .FirstOrDefault();

                this.ProductBoardContext.ProductBoards.Remove(productBoard);
                await this.ProductBoardContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Product board failed!", ex);
            }
        }
    }
}