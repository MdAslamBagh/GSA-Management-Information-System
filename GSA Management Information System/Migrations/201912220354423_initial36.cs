namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Total_USD_With_SSC_Vat", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoSalesInformations", "Total_USD_With_SSC_Vat");
        }
    }
}
