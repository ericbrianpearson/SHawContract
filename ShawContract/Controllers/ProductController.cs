using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Models.Cart;
using ShawContract.Models.Product;

namespace ShawContract.Controllers
{
    public class ProductController : BaseController
    {
        private IProductsService ProductsService { get; }

        private IShoppingCartService ShoppingCartService { get; }
        private IProductBoardService ProductBoardService { get; }


        public ProductController(IMasterPageService masterPageService, IProductsService productsService, IShoppingCartService shoppingCartService, IProductBoardService productBoardService)
            : base(masterPageService)
        {
            this.ProductsService = productsService;
            this.ShoppingCartService = shoppingCartService;
            this.ProductBoardService = productBoardService;
        }

        // GET: Product Details
        public ActionResult Details(string inventoryType, string nodeAlias, string colorNumber = null)
        {
            var page = this.ProductsService.GetProductPage(inventoryType, nodeAlias);
            var collectionItems = this.ProductsService.GetCollectionItems(page.Collection, inventoryType);
            var similarItems = this.ProductsService.GetSimilarProducts(page.SimilarProducts, inventoryType);
            var productBoards = this.ProductBoardService.GetProductBoards(this.User.Identity.Name);

            var model = this.GetPageViewModel(new ProductDetailsViewModel(this.User.Identity.Name, page, collectionItems, similarItems, productBoards, colorNumber), nodeAlias);
            model.Data.UserId = this.User.Identity.Name;
            ViewData["Data"] = model.Data;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProductToShoppingCart(int colorId)
        {
            this.ShoppingCartService.AddItemToCart(colorId, 1);
            return new EmptyResult();
        }

        public ActionResult Unauthorized(string inventoryType, string nodeAlias)
        {      
                return RedirectToAction("RequestSignIn", "Account", new { provider = "", returnUrl = Url.Action("Details", "Product", new { inventoryType, nodeAlias}) });
            
        }
        public async Task<ActionResult> CreateProductToBoard(string boardName, string userId, ProductBoardItem productBoardItem)
        {            
            var productBoard = new ProductBoard
            {
                BoardName = boardName,
                UserId = userId,
                ProductBoardItems = new List<ProductBoardItem>()
            };
            productBoard.ProductBoardItems.Add(productBoardItem);
            var result = await this.ProductBoardService.CreateProductBoardAsync(productBoard);
            var response = new { id = result.ToString() };
            return Json(response, JsonRequestBehavior.DenyGet);
        }

        public async Task<ActionResult> AddProductBoardItem(Guid boardId, ProductBoardItem productBoardItem)
        {
            await this.ProductBoardService.AddProductBoardItemAsync(boardId, productBoardItem);
            return new EmptyResult();
        }
    }
}