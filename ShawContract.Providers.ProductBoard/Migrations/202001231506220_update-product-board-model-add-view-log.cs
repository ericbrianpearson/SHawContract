namespace ShawContract.Providers.ProductBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproductboardmodeladdviewlog : DbMigration
    {
        public override void Up()
        {
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
            
            AlterColumn("dbo.ProductBoardItem", "StyleName", c => c.String(nullable: false));
            AlterColumn("dbo.ProductBoardItem", "StyleNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ProductBoardItem", "ColorName", c => c.String(nullable: false));
            AlterColumn("dbo.ProductBoardItem", "ColorNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ProductBoardItem", "ImageUrl", c => c.String(nullable: false));
            DropColumn("dbo.ProductBoardItem", "Style");
            DropColumn("dbo.ProductBoardItem", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductBoardItem", "Color", c => c.String(nullable: false));
            AddColumn("dbo.ProductBoardItem", "Style", c => c.String(nullable: false));
            DropForeignKey("dbo.Visitor", "ProductBoardID", "dbo.ProductBoard");
            DropIndex("dbo.Visitor", new[] { "ProductBoardID" });
            AlterColumn("dbo.ProductBoardItem", "ImageUrl", c => c.String());
            AlterColumn("dbo.ProductBoardItem", "ColorNumber", c => c.String());
            AlterColumn("dbo.ProductBoardItem", "ColorName", c => c.String());
            AlterColumn("dbo.ProductBoardItem", "StyleNumber", c => c.String());
            AlterColumn("dbo.ProductBoardItem", "StyleName", c => c.String());
            DropTable("dbo.Visitor");
        }
    }
}
