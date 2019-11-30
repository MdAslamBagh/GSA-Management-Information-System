namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubMenuList = c.String(),
                        RoleId = c.String(),
                        RoleStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuItemInformations",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        Menu_Name = c.String(),
                        ModuleIcon = c.String(),
                    })
                .PrimaryKey(t => t.MenuItemId);
            
            CreateTable(
                "dbo.SubMenuInformations",
                c => new
                    {
                        SubMenuId = c.Int(nullable: false, identity: true),
                        Access_Name = c.String(),
                        MenuItemId = c.Int(nullable: false),
                        Controller_Name = c.String(),
                        Action_Name = c.String(),
                        IsVisible = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SubMenuId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubMenuInformations");
            DropTable("dbo.MenuItemInformations");
            DropTable("dbo.AccessInformations");
        }
    }
}
