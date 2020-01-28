using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models.ProductBoards
{
    public class ProductBoardsViewModel : IViewModel
    {
        public IEnumerable<ProductBoard> ProductBoards { get; set; }
    }
}