namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Receivable_Amount_USD_With_SSC_VAT", c => c.Single(nullable: false));
            DropColumn("dbo.CargoSalesInformations", "Total_SSC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesInformations", "Total_SSC", c => c.Single(nullable: false));
            DropColumn("dbo.CargoSalesInformations", "Receivable_Amount_USD_With_SSC_VAT");
        }
    }
}
