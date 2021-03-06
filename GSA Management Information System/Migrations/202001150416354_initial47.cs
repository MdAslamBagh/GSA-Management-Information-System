namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial47 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EditUserViewModels", "Company_Name", c => c.String());
            AddColumn("dbo.EditUserViewModels", "Branch_Name", c => c.String());
            AddColumn("dbo.EditUserViewModels", "Company_Code", c => c.String());
            AddColumn("dbo.EditUserViewModels", "Branch_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EditUserViewModels", "Branch_Code");
            DropColumn("dbo.EditUserViewModels", "Company_Code");
            DropColumn("dbo.EditUserViewModels", "Branch_Name");
            DropColumn("dbo.EditUserViewModels", "Company_Name");
        }
    }
}
