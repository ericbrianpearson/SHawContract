namespace ShawContract.Providers.ProductBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductBoardItem",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Notes = c.String(),
                        StyleName = c.String(nullable: false),
                        StyleNumber = c.String(nullable: false),
                        ColorName = c.String(nullable: false),
                        ColorNumber = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        ProductBoardID = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductBoard", t => t.ProductBoardID, cascadeDelete: true)
                .Index(t => t.ProductBoardID);
            
            CreateTable(
                "dbo.ProductBoard",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        BoardName = c.String(nullable: false, maxLength: 150),
                        Notes = c.String(),
                        UserId = c.String(nullable: false),
                        LoggedUserRequiredToAccess = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Visitor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        DateVisited = c.DateTime(nullable: false),
                        ProductBoardID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductBoard", t => t.ProductBoardID, cascadeDelete: true)
                .Index(t => t.ProductBoardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitor", "ProductBoardID", "dbo.ProductBoard");
            DropForeignKey("dbo.ProductBoardItem", "ProductBoardID", "dbo.ProductBoard");
            DropIndex("dbo.Visitor", new[] { "ProductBoardID" });
            DropIndex("dbo.ProductBoardItem", new[] { "ProductBoardID" });
            DropTable("dbo.Visitor");
            DropTable("dbo.ProductBoard");
            DropTable("dbo.ProductBoardItem");
        }
    }
}
