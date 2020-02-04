namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial61 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyInformations", "Company_Name", c => c.String());
            AlterColumn("dbo.CompanyInformations", "Company_Code", c => c.String());
            AlterColumn("dbo.CompanyInformations", "Branch_Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyInformations", "Branch_Name", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyInformations", "Company_Code", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyInformations", "Company_Name", c => c.String(nullable: false));
        }
    }
}
