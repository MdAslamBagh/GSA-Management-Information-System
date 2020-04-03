namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial108 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyInformations", "Company_Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyInformations", "Company_Email", c => c.String());
        }
    }
}
