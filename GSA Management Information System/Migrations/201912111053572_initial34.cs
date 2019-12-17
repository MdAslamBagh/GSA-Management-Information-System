namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial34 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoSalesTransactionBackups",
                c => new
                    {
                        CargoSalesId = c.Int(nullable: false, identity: true),
                        SalesSlno = c.Int(nullable: false),
                        MAWB = c.String(),
                        Check_Digit = c.String(),
                        Airway_No = c.String(),
                        Freighter_Code = c.Int(nullable: false),
                        Origin_Code = c.String(),
                        Dest_Code = c.String(),
                        Continent_Code = c.Int(nullable: false),
                        Payment_Mode = c.String(),
                        CFPaymode_Code = c.Int(nullable: false),
                        Route_Code = c.String(),
                        Customer_Code = c.String(),
                        Cargo_Code = c.String(),
                        UType_Code = c.Int(nullable: false),
                        HDS = c.Single(nullable: false),
                        AMS = c.Single(nullable: false),
                        Gross_Weight = c.Single(nullable: false),
                        Chargeable_Weight = c.Single(nullable: false),
                        Rate_Charge = c.Single(nullable: false),
                        B_Rate = c.Single(nullable: false),
                        AIT = c.Single(nullable: false),
                        Agent_Commission = c.Single(nullable: false),
                        HBL_Qty = c.Single(nullable: false),
                        Others = c.Single(nullable: false),
                        THC = c.Single(nullable: false),
                        SSC = c.Single(nullable: false),
                        FSC_Charge = c.Single(nullable: false),
                        ISS_Charge = c.Single(nullable: false),
                        SSC_VAT = c.Single(nullable: false),
                        Total_USD = c.Single(nullable: false),
                        Consignee_Code = c.String(),
                        Consignor_Code = c.String(),
                        Remarks = c.String(),
                        Currency_Code = c.String(),
                        Exchange_Rate = c.Single(nullable: false),
                        Receivable_Amount_USD_With_SSC_VAT = c.Single(nullable: false),
                        Receivable_Amount_BDT = c.Single(nullable: false),
                        Remarks_B_Bank = c.String(),
                        CheckSSCVat = c.Boolean(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.CargoSalesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoSalesTransactionBackups");
        }
    }
}
