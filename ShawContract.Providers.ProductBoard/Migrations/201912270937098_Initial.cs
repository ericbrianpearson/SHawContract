namespace ShawContract.Providers.ProductBoard.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductBoard",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    BoardName = c.String(nullable: false, maxLength: 150),
                    Notes = c.String(),
                    UserId = c.String(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.ProductBoardItem",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    Style = c.String(nullable: false),
                    Color = c.String(nullable: false),
                    Notes = c.String(),
                    ProductBoardID = c.Guid(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductBoard", t => t.ProductBoardID, cascadeDelete: true)
                .Index(t => t.ProductBoardID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductBoardItem", "ProductBoardID", "dbo.ProductBoard");
            DropIndex("dbo.ProductBoardItem", new[] { "ProductBoardID" });
            DropTable("dbo.ProductBoardItem");
            DropTable("dbo.ProductBoard");
        }
    }
}
