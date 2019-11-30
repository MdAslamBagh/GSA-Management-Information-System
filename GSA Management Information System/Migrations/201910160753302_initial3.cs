namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CargoSalesInformations", "HDS", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "AMS", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Gross_Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Chargeable_Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Rate_Charge", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "B_Rate", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "AIT", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Agent_Commission", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "HBL_Qty", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Others", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "THC", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "SSC", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "FSC_Charge", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "ISS_Charge", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "SSC_VAT", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Total_USD", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Total_SSC", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Receivable_Amount_BDT", c => c.Single(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Payable_Agent_CC", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CargoSalesInformations", "Payable_Agent_CC", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Receivable_Amount_BDT", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Total_SSC", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Total_USD", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "SSC_VAT", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "ISS_Charge", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "FSC_Charge", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "SSC", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "THC", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Others", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "HBL_Qty", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Agent_Commission", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "AIT", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "B_Rate", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Rate_Charge", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Chargeable_Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "Gross_Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "AMS", c => c.Int(nullable: false));
            AlterColumn("dbo.CargoSalesInformations", "HDS", c => c.Int(nullable: false));
        }
    }
}
