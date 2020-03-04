using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using System.Threading.Tasks;
using System;
using ShawContract.Models.ProductBoards;
using ShawContract.Application.Models;
using ShawContract.Utils;

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
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult MyBoards()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("RequestSignIn", "Account", new { provider = "", returnUrl = Url.Action("MyBoards", "ProductBoards") });
            }
            var productBoards = ProductBoardService.GetProductBoards(this.User.Identity.Name);
            
            if (productBoards == null) return HttpNotFound();

            var boardModel = new ProductBoardsViewModel() { ProductBoards = productBoards };
            var model = this.GetPageViewModel(boardModel, "ProductBoards");

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditBoard(string boardId)
        {
            var board = ProductBoardService.GetProductBoard(Guid.Parse(boardId));
            if (board == null) return HttpNotFound();

            var boardModel = new ProductBoardDetailsViewModel() { ProductBoard = board };
            boardModel.BoardUrl = ExtensionMethods.CreateBoardUrl(boardId, MasterPageService.SiteContext.CurrentSiteCulture);
            var model = this.GetPageViewModel(boardModel, "ProductBoardDetails");

            return View(model);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBoard(string boardName)
        {
            var user = CMS.Membership.MembershipContext.AuthenticatedUser;

            var board = new ProductBoard() { BoardName = boardName, UserId = user.Email };
            var result = await ProductBoardService.CreateProductBoardAsync(board);

            return RedirectToAction("EditBoard", new { boardId = result.ToString()});
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductBoard board)
        {
            var user = CMS.Membership.MembershipContext.AuthenticatedUser;
            if (user.Email.ToLowerInvariant() == board.UserId.ToLowerInvariant())
            {
                await ProductBoardService.UpdateProductBoardAsync(board);
                return RedirectToAction("EditBoard", new { boardId = board.ID.ToString() });
            }

            return HttpNotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RenameBoard(string id, string boardName)
        {
            var boardToRename = ProductBoardService.GetProductBoard(Guid.Parse(id));
            boardToRename.BoardName = boardName;
            await ProductBoardService.UpdateProductBoardAsync(boardToRename);

            return RedirectToAction("EditBoard", new { boardId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveBoard(string boardId)
        {
            await ProductBoardService.DeleteProductBoardAsync(Guid.Parse(boardId));

            return RedirectToAction("MyBoards"); 
        }

        public async Task<ActionResult> RemoveItem(string boardId, string productId)
        {
            await ProductBoardService.RemoveProductBoardItemAsync(Guid.Parse(boardId), Guid.Parse(productId));
            var boardModel = new ProductBoardDetailsViewModel() { ProductBoard = ProductBoardService.GetProductBoard(Guid.Parse(boardId))};
            var model = GetPageViewModel(boardModel, "ProductBoardDetails");

            return View("EditBoard", model);
        }

        public ActionResult SharedBoard(string boardId)
        {
            if (Request.IsAuthenticated)
            {
                var userEmail = CMS.Membership.MembershipContext.AuthenticatedUser.Email;
                ProductBoardService.AddVisitorToLog(Guid.Parse(boardId), new Visitor() { Email = userEmail, DateVisited = DateTime.UtcNow });
            }

            var board = ProductBoardService.GetProductBoard(Guid.Parse(boardId));
            var boardUrl = ExtensionMethods.CreateBoardUrl(boardId, MasterPageService.SiteContext.CurrentSiteCulture);


            if (board == null) return HttpNotFound();

            return View("SharedBoard", new SelectedBoardViewModel() { Board = board, BoardUrl = boardUrl });
        }    

    }
}