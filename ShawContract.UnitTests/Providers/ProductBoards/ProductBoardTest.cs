using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShawContract.Providers.ProductBoard;
using ShawContract.Config;
using ShawContract.Application.Models;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

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
                             StyleName ="Style 1",
                              ColorName="blue",
                               Notes="some board item notes"
                        },
                         new ProductBoardItem
                        {
                             StyleName ="Style 2",
                              ColorName="blue",
                               Notes="some board item notes"
                        },
                          new ProductBoardItem
                        {
                             StyleName ="Style 3",
                              ColorName="blue",
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
            var allBoards = this.ProductBoardGateway.GetProductBoards("TestUser@gmail.com");
            var firstBoard = allBoards.FirstOrDefault();

            firstBoard.BoardName = boardNewName;

            await this.ProductBoardGateway.UpdateProductBoardAsync(firstBoard);
            var updatedBoard =  this.ProductBoardGateway.GetProductBoard(firstBoard.ID);

            Assert.IsTrue(updatedBoard.BoardName == boardNewName);
        }

        [TestMethod]
        public async Task AddBoardItemAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var allBoards = this.ProductBoardGateway.GetProductBoards("TestUser@gmail.com");
            var firstBoard = allBoards.FirstOrDefault();
            var productCount = firstBoard.ProductBoardItems.Count;

            await this.ProductBoardGateway.AddProductBoardItemAsync(firstBoard.ID, new ProductBoardItem
            {
                ColorName = "Color",
                StyleName = "Style",
                Notes = "Notes"
            });
            var updatedBoard = this.ProductBoardGateway.GetProductBoard(firstBoard.ID);
            Assert.IsTrue(updatedBoard.ProductBoardItems.Count() == (productCount + 1));
        }

        [TestMethod]
        public async Task RemoveBoardItemAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var allBoards = this.ProductBoardGateway.GetProductBoards("TestUser@gmail.com");
            var firstBoard = allBoards.FirstOrDefault();
            var productCount = firstBoard.ProductBoardItems.Count;

            await this.ProductBoardGateway.RemoveProductBoardItemAsync(firstBoard.ID, firstBoard.ProductBoardItems.First().ID);

            var updatedBoard = this.ProductBoardGateway.GetProductBoard(firstBoard.ID);
            Assert.IsTrue(updatedBoard.ProductBoardItems.Count() == (productCount - 1));
        }

        [TestMethod]
        public async Task DeleteAllBoardsAssert()
        {
            await this.ProductBoardGateway.CreateProductBoardAsync(this.Board);
            var allBoards = this.ProductBoardGateway.GetProductBoards("TestUser@gmail.com");

            foreach (var item in allBoards)
            {
                await this.ProductBoardGateway.DeleteProductBoardAsync(item.ID);
            }
            var noBoards = this.ProductBoardGateway.GetProductBoards("TestUser@gmail.com");

            Assert.IsTrue(noBoards.Count() == 0);
        }
    }
}