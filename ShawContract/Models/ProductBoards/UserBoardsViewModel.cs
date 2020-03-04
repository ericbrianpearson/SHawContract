using System.Collections.Generic;
using ShawContract.Application.Models;

namespace ShawContract.Models.ProductBoards
{
    public class UserBoardsViewModel
    {
        public IEnumerable<ProductBoard> Boards { get; set; }
        public SelectedBoardViewModel SelectedBoard { get; set; }
    }
}