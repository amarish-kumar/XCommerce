namespace XCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImagePathInProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
        }
    }
}
