namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial69 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Others_Charges", c => c.Single(nullable: false));
            AddColumn("dbo.CargoSalesTransactionBackups", "Others_Charges", c => c.Single(nullable: false));
            DropColumn("dbo.CargoSalesInformations", "Others");
            DropColumn("dbo.CargoSalesTransactionBackups", "Others");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesTransactionBackups", "Others", c => c.Single(nullable: false));
            AddColumn("dbo.CargoSalesInformations", "Others", c => c.Single(nullable: false));
            DropColumn("dbo.CargoSalesTransactionBackups", "Others_Charges");
            DropColumn("dbo.CargoSalesInformations", "Others_Charges");
        }
    }
}
