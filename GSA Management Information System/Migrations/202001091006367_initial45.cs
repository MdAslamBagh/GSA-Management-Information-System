namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInformations", "Company_Code", c => c.String());
            AddColumn("dbo.UserInformations", "Branch_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInformations", "Branch_Code");
            DropColumn("dbo.UserInformations", "Company_Code");
        }
    }
}
