namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial43 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyInformations", "Company_Tin", c => c.String());
            AlterColumn("dbo.CompanyInformations", "Company_Address", c => c.String());
            AlterColumn("dbo.CompanyInformations", "Company_Postcode", c => c.String());
            AlterColumn("dbo.CompanyInformations", "Company_City", c => c.String());
            AlterColumn("dbo.CompanyInformations", "Company_Country", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyInformations", "Company_Country", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyInformations", "Company_City", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyInformations", "Company_Postcode", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyInformations", "Company_Address", c => c.String(nullable: false));
            AlterColumn("dbo.CompanyInformations", "Company_Tin", c => c.String(nullable: false));
        }
    }
}
