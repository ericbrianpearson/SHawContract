using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShawContract.Application.Models;
using ShawContract.Config;
using ShawContract.Providers.ProductBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shaw.Contract.UnitTests.Providers.ProductBoards
{
    /// <summary>
    /// Summary description for ProductBoardTest
    /// </summary>
    [TestClass]
    public class ProductBoardTest
    {
        private ProductBoardGateway ProductBoardGateway { get; }
        private ProductBoard Board { get; }

        private IMapper Mapper { get; }

        public ProductBoardTest()
        {
            this.Mapper = AutoMapperConfig.RegisterAutoMappings();
            this.ProductBoardGateway = new ProductBoardGateway(AutoMapperConfig.RegisterAutoMappings());
            this.Board = new ProductBoard
            {
                BoardName = "Board name",
                Notes = "Some notes",
                UserId = "TestUser@gmail.com",
                ProductBoardItems = new List<ProductBoardItem>
                    {
                        new ProductBoardItem
                        {
                             Style ="Style 1",
                              Color="blue",
                               Notes="some board item notes"
                        },
                         new ProductBoardItem
                        {
                             Style ="Style 2",
                              Color="blue",
                               Notes="some board item notes"
                        },
                          new ProductBoardItem
                        {
                             Style ="Style 3",
                              Color="blue",
                               Notes="some board item notes"
                        }
                    }
            };
        }

        [TestMethod]
        public async Task CreateProductBoardAssert()
        {
            var boardID = await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);

            Assert.AreNotEqual(Guid.Empty, boardID);
        }

        [TestMethod]
        public async Task UpdateBoardNameAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var boardNewName = "UpdatedName";
            var allBoards = await this.ProductBoardGateway.GetProductBoardsAsync("TestUser@gmail.com");
            var firstBoard = allBoards.FirstOrDefault();

            firstBoard.BoardName = boardNewName;

            await this.ProductBoardGateway.UpdateProductBoardAsync(firstBoard);
            var updatedBoard = await this.ProductBoardGateway.GetProductBoardAsync(firstBoard.ID);

            Assert.IsTrue(updatedBoard.BoardName == boardNewName);
        }

        [TestMethod]
        public async Task AddBoardItemAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var allBoards = await this.ProductBoardGateway.GetProductBoardsAsync("TestUser@gmail.com");
            var firstBoard = allBoards.FirstOrDefault();
            var productCount = firstBoard.ProductBoardItems.Count;

            await this.ProductBoardGateway.AddProductBoardItemAsync(firstBoard.ID, new ProductBoardItem
            {
                Color = "Color",
                Style = "Style",
                Notes = "Notes"
            });
            var updatedBoard = await this.ProductBoardGateway.GetProductBoardAsync(firstBoard.ID);
            Assert.IsTrue(updatedBoard.ProductBoardItems.Count() == (productCount + 1));
        }

        [TestMethod]
        public async Task RemoveBoardItemAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var allBoards = await this.ProductBoardGateway.GetProductBoardsAsync("TestUser@gmail.com");
            var firstBoard = allBoards.FirstOrDefault();
            var productCount = firstBoard.ProductBoardItems.Count;

            await this.ProductBoardGateway.RemoveProductBoardItemAsync(firstBoard.ID, firstBoard.ProductBoardItems.First().ID);

            var updatedBoard = await this.ProductBoardGateway.GetProductBoardAsync(firstBoard.ID);
            Assert.IsTrue(updatedBoard.ProductBoardItems.Count() == (productCount - 1));
        }

        [TestMethod]
        public async Task DeleteAllBoardsAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var allBoards = await this.ProductBoardGateway.GetProductBoardsAsync("TestUser@gmail.com");

            foreach (var item in allBoards)
            {
                await this.ProductBoardGateway.DeleteProductBoardAsync(item.ID);
            }
            var noBoards = await this.ProductBoardGateway.GetProductBoardsAsync("TestUser@gmail.com");

            Assert.IsTrue(noBoards.Count() == 0);
        }
    }
}