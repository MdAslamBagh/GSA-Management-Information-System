namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInformations", "Default_Code", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyInformations", "Default_Code");
        }
    }
}
