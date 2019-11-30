namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EditUserViewModels", "UserName", c => c.String());
            DropColumn("dbo.EditUserViewModels", "NameIdentifier");
            DropColumn("dbo.AspNetUsers", "NameIdentifier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NameIdentifier", c => c.String());
            AddColumn("dbo.EditUserViewModels", "NameIdentifier", c => c.String());
            DropColumn("dbo.EditUserViewModels", "UserName");
        }
    }
}
