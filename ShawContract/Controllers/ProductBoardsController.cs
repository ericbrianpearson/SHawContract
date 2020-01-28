using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using System.Threading.Tasks;
using System;
using ShawContract.Models.ProductBoards;
using ShawContract.Application.Models;
using System.Linq;
using System.Collections.Generic;

namespace ShawContract.Controllers
{
    public class ProductBoardsController : BaseController
    {
        private IProductBoardService ProductBoardService { get; }
        public ProductBoardsController(IMasterPageService masterPageService, IProductBoardService productBoardService)
             : base(masterPageService)
        {
            this.ProductBoardService = productBoardService;
        }

        // GET: Product boards
        //[Authorize]
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public async Task<ActionResult> MyBoards()
        {
            var userId = "TestUserId";
            var productBoards = await ProductBoardService.GetProductBoardsAsync(userId);
            if (productBoards == null) return HttpNotFound();

            var boardModel = new ProductBoardsViewModel() { ProductBoards = productBoards };
            var model = this.GetPageViewModel(boardModel, "ProductBoards");

            return View(model);
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult> Details(string nodeAlias, string boardId)
        {
            var board = await ProductBoardService.GetProductBoardAsync(Guid.Parse(boardId));
            if (board == null) return HttpNotFound();

            var boardModel = new ProductBoardDetailsViewModel() { ProductBoard = board };
            var model = this.GetPageViewModel(boardModel, "ProductBoardDetails");

            return View(model);

        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBoard(string nodeAlias,string boardName)
        {
            var userId = "SomeUserId";
            var board = new ProductBoard() { BoardName = boardName, UserId = userId };
            var result = await ProductBoardService.CreateProductBoardAsync(board);

            return RedirectToAction("MyBoards");
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBoard(string nodeAlias, ProductBoard board)
        {
            await ProductBoardService.UpdateProductBoardAsync(board);
            return RedirectToAction("Details", new { nodeAlias = nodeAlias, boardId = board.ID.ToString() });
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RenameBoard(string nodeAlias, string id, string boardName)
        {
            var boardToRename = await ProductBoardService.GetProductBoardAsync(Guid.Parse(id));
            boardToRename.BoardName = boardName;
            await ProductBoardService.UpdateProductBoardAsync(boardToRename);

            return RedirectToAction("Details", new { nodeAlias = nodeAlias, boardId = id });
        }

        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveBoard(string nodeAlias, string boardId)
        {
            await ProductBoardService.DeleteProductBoardAsync(Guid.Parse(boardId));

            return RedirectToAction("MyBoards"); 
        }


        //[Authorize]
        public async Task<ActionResult> RemoveItem(string nodeAlias, string boardId, string productId)
        {
            await ProductBoardService.RemoveProductBoardItemAsync(Guid.Parse(boardId), Guid.Parse(productId));
            var boardModel = new ProductBoardDetailsViewModel() { ProductBoard = await ProductBoardService.GetProductBoardAsync(Guid.Parse(boardId))};
            var model = GetPageViewModel(boardModel, nodeAlias);

            return View("Details", model);
        }

        //Not done yet, may be implemented with kentico smart search
        //[Authorize]
        [HttpPost]
        public JsonResult Search(string term)
        {
            List<ProductBoardItem> itemsList = new List<ProductBoardItem>()
            {
                new ProductBoardItem(){StyleName = "Search product 1", ColorName = "Blue", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
                new ProductBoardItem(){StyleName = "test something", ColorName = "Red", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
                new ProductBoardItem(){StyleName = "resilient", ColorName = "Blue", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
                new ProductBoardItem(){StyleName = "carpet", ColorName = "purple", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
                new ProductBoardItem(){StyleName = "bla bla", ColorName = "green", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
                new ProductBoardItem(){StyleName = "another moket", ColorName = "gray", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
                new ProductBoardItem(){StyleName = "lalala", ColorName = "Blue", Notes = "Some notes here", StyleNumber = "5T3321", ColorNumber = "011105", ID = Guid.NewGuid(), ImageUrl = "https://images.unsplash.com/photo-1541233349642-6e425fe6190e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
            };

            var result = itemsList.Where(i => i.StyleName.ToLower().Contains(term.ToLower()) ||
                                         i.StyleNumber.ToLower().Contains(term.ToLower()))
                                         .Select(i => i).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}