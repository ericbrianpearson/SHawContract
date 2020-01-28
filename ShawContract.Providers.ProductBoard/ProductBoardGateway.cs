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

        private static List<Models.ProductBoardItem> MockedBoardItems = new List<Models.ProductBoardItem>
                {
                    new Models.ProductBoardItem() { StyleName = "Product name 1", ColorName = "Color name 1", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80" },
                    new Models.ProductBoardItem() { StyleName = "Product name 2", ColorName = "Color name 2", Notes = "Some notes here", StyleNumber = "5T3323", ColorNumber = "011106", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80" },
                    new Models.ProductBoardItem() { StyleName = "Product name 3", ColorName = "Color name 3", Notes = "Some notes here", StyleNumber = "5T3324", ColorNumber = "011107", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80" },
                    new Models.ProductBoardItem() { StyleName = "Product name 4", ColorName = "Color name 4", Notes = "Some notes here", StyleNumber = "5T3325", ColorNumber = "011108", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80" }
                };

        private static List<Models.ProductBoard> MockedBoards = new List<Models.ProductBoard>()
        {
           new Models.ProductBoard() { BoardName = "Some test board 1", ID = Guid.NewGuid(), Notes = "Description description on display, which board is mightiest of them all?", LoggedUserRequiredToAccess = false, UserId = "TestUserId", ProductBoardItems = MockedBoardItems },
           new Models.ProductBoard() { BoardName = "Some test board 2", ID = Guid.NewGuid(), Notes = "Description description on display, which board is mightiest of them all?", LoggedUserRequiredToAccess = false, UserId = "TestUserId", ProductBoardItems = MockedBoardItems },
           new Models.ProductBoard() { BoardName = "Some test board 3", ID = Guid.NewGuid(), Notes = "Description description on display, which board is mightiest of them all?", LoggedUserRequiredToAccess = true, UserId = "TestUserId", ProductBoardItems = MockedBoardItems }
        };

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
                //this.ProductBoardContext.ProductBoards.Add(board);
                //await this.ProductBoardContext.SaveChangesAsync();

                MockedBoards.Add(board);
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
                //var item = await this.ProductBoardContext.ProductBoards
                //.Where(b => b.ID == boardID)
                //.Include(b => b.ProductBoardItems)
                //.FirstOrDefaultAsync();
                var item = MockedBoards.FirstOrDefault(b => b.ID == boardID);

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
                //var items = await this.ProductBoardContext.ProductBoards
                //.Where(b => b.UserId == userId)
                //.Include(b => b.ProductBoardItems)
                //.ToListAsync();               
                var mapped = this.Mapper.Map<List<Application.Models.ProductBoard>>(MockedBoards);
                return mapped;
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
                //var board = await this.ProductBoardContext.ProductBoards
                //    .Where(p => p.ID == productBoard.ID)
                //    .FirstOrDefaultAsync();

                var board = MockedBoards.FirstOrDefault(b => b.ID == productBoard.ID);
                var mappedBoard = Mapper.Map<Models.ProductBoard>(productBoard);
                board.ModifiedOn = DateTime.UtcNow;
                board.LoggedUserRequiredToAccess = productBoard.LoggedUserRequiredToAccess;
                board.Notes = productBoard.Notes;
                board.BoardName = productBoard.BoardName;
                board.ProductBoardItems = mappedBoard.ProductBoardItems;

                //await this.ProductBoardContext.SaveChangesAsync();
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
                var productBoard = MockedBoards.FirstOrDefault(b => b.ID == boardId);

                //var productBoard = await this.ProductBoardContext.ProductBoards.FirstOrDefaultAsync(p => p.ID == boardId);
                var productItemToAdd = this.Mapper.Map<Models.ProductBoardItem>(productBoardItem);
                productItemToAdd.ID = Guid.NewGuid();
                productItemToAdd.ModifiedOn = DateTime.UtcNow;
                productItemToAdd.CreatedOn = DateTime.UtcNow;
                //productBoard.ProductBoardItems.Add(productItemToAdd);

                productBoard.ProductBoardItems.Add(productItemToAdd);

                //await this.ProductBoardContext.SaveChangesAsync();
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
                var productBoard = MockedBoards.FirstOrDefault(b => b.ID == boardId);
                //var productBoard = await this.ProductBoardContext.ProductBoards.FirstOrDefaultAsync(p => p.ID == boardId);
                var productBoardItem = productBoard.ProductBoardItems.FirstOrDefault(i => i.ID == productId);
                //this.ProductBoardContext.ProductBoardItems.Remove(productBoardItem);
                productBoard.ProductBoardItems.Remove(productBoardItem);
                //await this.ProductBoardContext.SaveChangesAsync();
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
                //Models.ProductBoard productBoard = this.ProductBoardContext
                //    .ProductBoards
                //    .Where(b => b.ID == productBoardID)
                //    .FirstOrDefault();

                //this.ProductBoardContext.ProductBoards.Remove(productBoard);
                //await this.ProductBoardContext.SaveChangesAsync();

                var boardToRemove = MockedBoards.FirstOrDefault(b => b.ID == productBoardID);
                MockedBoards.Remove(boardToRemove);
            }
            catch (Exception ex)
            {
                throw new Exception("Delete Product board failed!", ex);
            }
        }

        public async Task AddUserToViewersLog(Guid boardId, Application.Models.Visitor visitor)
        {
            var board = this.ProductBoardContext.ProductBoards
                            .Where(b => b.ID == boardId)
                            .FirstOrDefault();

            board.Visitors.Add(Mapper.Map<Models.Visitor>(visitor));
            await this.ProductBoardContext.SaveChangesAsync();
        }
    }
}