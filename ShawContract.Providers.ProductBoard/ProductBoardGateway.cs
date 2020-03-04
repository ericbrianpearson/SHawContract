using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Providers.ProductBoard.DAL;

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

        public Application.Models.ProductBoard GetProductBoard(Guid boardID)
        {
            try
            {
                var item =  this.ProductBoardContext.ProductBoards
                .Where(b => b.ID == boardID)
                .Include(b => b.ProductBoardItems)
                .Include(b => b.Visitors)
                .FirstOrDefault();
                item.Visitors = item.Visitors.OrderByDescending(i => i.DateVisited).ToList();

                var mappedBoard = this.Mapper.Map<Application.Models.ProductBoard>(item);
                AddDisplayDate(mappedBoard);
                return mappedBoard;
            }
            catch (Exception ex)
            {
                throw new Exception("Get Product boards failed!", ex);
            }
        }

        public IEnumerable<Application.Models.ProductBoard> GetProductBoards(string userId)
        {
            try
            {
                var items = this.ProductBoardContext.ProductBoards
               .Where(b => b.UserId == userId)
               .Include(b => b.ProductBoardItems)
               .Include(b => b.Visitors)
               .ToList();
                var mappedItems = this.Mapper.Map<List<Application.Models.ProductBoard>>(items);
                mappedItems.ForEach(i => AddDisplayDate(i));
                return mappedItems;
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
                
                var mappedBoard = Mapper.Map<Models.ProductBoard>(productBoard);
                board.ModifiedOn = DateTime.UtcNow;
                board.LoggedUserRequiredToAccess = productBoard.LoggedUserRequiredToAccess;
                board.Notes = productBoard.Notes;
                board.BoardName = productBoard.BoardName;
                UpdateBoardItems(productBoard.ProductBoardItems, board.ProductBoardItems);

                await this.ProductBoardContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Update Product board failed!", ex);
            }
        }

        private void UpdateBoardItems(List<Application.Models.ProductBoardItem> productBoardItems, ICollection<Models.ProductBoardItem> oldBoardItems)
        {
            foreach (var item in productBoardItems)
            {
                oldBoardItems.FirstOrDefault(i => i.ID == item.ID).Notes = item.Notes;
            }
        }

        public async Task AddProductBoardItemAsync(Guid boardId, Application.Models.ProductBoardItem productBoardItem)
        {
            try
            {
                var productBoard = await this.ProductBoardContext.ProductBoards.FirstOrDefaultAsync(p => p.ID == boardId);

                var productItemToAdd = this.Mapper.Map<Models.ProductBoardItem>(productBoardItem);
                productItemToAdd.ID = Guid.NewGuid();
                productItemToAdd.CreatedOn = DateTime.UtcNow;
                productItemToAdd.ModifiedOn = productItemToAdd.CreatedOn;
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
                productBoard.ProductBoardItems.Remove(productBoardItem);
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

        public void AddUserToViewersLog(Guid boardId, Application.Models.Visitor visitor)
        {
            var board = this.ProductBoardContext.ProductBoards
                            .Where(b => b.ID == boardId)
                            .Include(b => b.Visitors)
                            .FirstOrDefault();

            visitor.Id = Guid.NewGuid();
            visitor.DateVisited = DateTime.UtcNow;

            if (board != null)
            {
                board.Visitors.Add(Mapper.Map<Models.Visitor>(visitor));
                this.ProductBoardContext.SaveChanges();
            }
        }
        private void AddDisplayDate(Application.Models.ProductBoard mappedBoard)
        {
            var date = mappedBoard.LastModied.Hours < 1 ? string.Format("Last Updated: {0} minutes ago", mappedBoard.LastModied.Minutes)
           : string.Format("Last Updated: {0} hours ago", mappedBoard.LastModied.Hours);
            mappedBoard.DisplayDate = mappedBoard.LastModied.Days < 1 ? date
                          : string.Format("Last Updated: {0}", mappedBoard.ModifiedOn.ToString("MMMM dd"));
        }
    }
}