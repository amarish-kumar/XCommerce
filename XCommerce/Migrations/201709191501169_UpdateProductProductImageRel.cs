namespace XCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductProductImageRel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProductImages", "ProductId");
            AddForeignKey("dbo.ProductImages", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
        }
    }
}
