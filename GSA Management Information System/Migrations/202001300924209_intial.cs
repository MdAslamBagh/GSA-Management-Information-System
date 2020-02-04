namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "IsSSCVAT", c => c.Boolean(nullable: false));
            AddColumn("dbo.CargoSalesTransactionBackups", "IsSSCVAT", c => c.Boolean(nullable: false));
            DropColumn("dbo.CargoSalesInformations", "CheckSSCVat");
            DropColumn("dbo.CargoSalesTransactionBackups", "CheckSSCVat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesTransactionBackups", "CheckSSCVat", c => c.Boolean(nullable: false));
            AddColumn("dbo.CargoSalesInformations", "CheckSSCVat", c => c.Boolean(nullable: false));
            DropColumn("dbo.CargoSalesTransactionBackups", "IsSSCVAT");
            DropColumn("dbo.CargoSalesInformations", "IsSSCVAT");
        }
    }
}
