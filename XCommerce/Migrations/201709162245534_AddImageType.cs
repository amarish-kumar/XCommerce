namespace XCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ProductImages", "ImageTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductImages", "ImageTypeId");
            AddForeignKey("dbo.ProductImages", "ImageTypeId", "dbo.ImageTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "ImageTypeId", "dbo.ImageTypes");
            DropIndex("dbo.ProductImages", new[] { "ImageTypeId" });
            DropColumn("dbo.ProductImages", "ImageTypeId");
            DropTable("dbo.ImageTypes");
        }
    }
}
