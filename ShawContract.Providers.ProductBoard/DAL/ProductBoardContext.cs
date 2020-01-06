using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShawContract.Providers.ProductBoard.DAL
{
    public class ProductBoardContext : DbContext, IProductBoardContext
    {
        public DbSet<Models.ProductBoard> ProductBoards { get; set; }
        public DbSet<Models.ProductBoardItem> ProductBoardItems { get; set; }

        public ProductBoardContext() : base(nameOrConnectionString: "ProductBoardsConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}