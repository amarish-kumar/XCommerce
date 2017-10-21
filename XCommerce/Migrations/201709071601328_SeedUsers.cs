namespace XCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a7cb49fa-f223-41a4-a63c-a9e27593f10e', N'admin@vidly.com', 0, N'AKr3Qy+IiRnGNUU1NZZvuyS7g2Dap/HZWW7WH4+gZDDi702duNgR/43JrU915XiOLg==', N'05121053-ff88-477f-bd41-71963d602a8c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'afe9bf2a-f047-40d9-a4b0-17c845820eba', N'guest@vidly.com', 0, N'AJuLKutU8MoCefpgYWMGP3iCOg6b5++v1fP1+e7AjUjFHXafy4RtYX0GmQHvhVQKWg==', N'b510883a-8d92-4793-b057-fdcd83f497d5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c51d9bdb-b251-425d-b07d-6262560bb969', N'CanManageProducts')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
