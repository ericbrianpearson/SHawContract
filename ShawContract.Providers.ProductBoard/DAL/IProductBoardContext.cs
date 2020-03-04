using System.Data.Entity;

namespace ShawContract.Providers.ProductBoard.DAL
{
    public interface IProductBoardContext
    {
        DbSet<Models.ProductBoard> ProductBoards { get; set; }

        DbSet<Models.ProductBoardItem> ProductBoardItems { get; set; }
        DbSet<Models.Visitor> Visitors { get; set; }
    }
}