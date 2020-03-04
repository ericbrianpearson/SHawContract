using System.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.ProductBoards;
using System.Threading.Tasks;
using System;
using System.Linq;
using ShawContract.Utils;

namespace ShawContract.Controllers
{
    public class ProductBoardsDropDownController : BaseController
    {
        private IProductBoardService ProductBoards { get; }

        public ProductBoardsDropDownController(IMasterPageService masterPageService, IProductBoardService productBoards) : base(masterPageService)
        {
            this.ProductBoards = productBoards;
        }
        // GET: ProductBoardsDropDown
        [Authorize]
        public ActionResult Boards()
        {
            var userBoards = ProductBoards.GetProductBoards(this.User.Identity.Name);
            var model = new UserBoardsViewModel() { Boards = userBoards };
            if (userBoards.Count() > 0)
            {
                var boardModel = new SelectedBoardViewModel() { Board = userBoards.FirstOrDefault() };
                boardModel.BoardUrl = ExtensionMethods.CreateBoardUrl(boardModel.Board.ID.ToString(), MasterPageService.SiteContext.CurrentSiteCulture);
                var viewModel = new UserBoardsViewModel() { Boards = userBoards, SelectedBoard = boardModel };
                return PartialView("_ProductBoardsDropDownPartial", viewModel);
            }
            return PartialView("_ProductBoardsDropDownPartial", model);
        }

        [Authorize]
        public ActionResult GetBoard(string boardId)
        {
            var board = ProductBoards.GetProductBoard(Guid.Parse(boardId));
            var model = new SelectedBoardViewModel() { Board = board };
            model.BoardUrl = ExtensionMethods.CreateBoardUrl(model.Board.ID.ToString(), MasterPageService.SiteContext.CurrentSiteCulture);

            return PartialView("_SelectedBoardPartial", model);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> RemoveItem(string boardId, string itemId)
        {
            await ProductBoards.RemoveProductBoardItemAsync(Guid.Parse(boardId), Guid.Parse(itemId));
            return RedirectToAction("GetBoard", new { boardId = boardId });
        }

    }
}