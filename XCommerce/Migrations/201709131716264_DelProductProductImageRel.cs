namespace XCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelProductProductImageRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ProductImages", "ProductId");
            AddForeignKey("dbo.ProductImages", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
