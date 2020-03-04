using ShawContract.Application.Models;

namespace ShawContract.Models.ProductBoards
{
    public class ProductBoardDetailsViewModel : IViewModel
    {
        public ProductBoard ProductBoard { get; set; }
        public string BoardUrl { get; set; }
    }
}