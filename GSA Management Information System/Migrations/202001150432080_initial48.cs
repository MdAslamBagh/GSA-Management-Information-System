namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Company_Code", c => c.String());
            AddColumn("dbo.AspNetUsers", "Branch_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Branch_Code");
            DropColumn("dbo.AspNetUsers", "Company_Code");
        }
    }
}
