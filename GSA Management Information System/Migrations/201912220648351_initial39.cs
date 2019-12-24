namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesTransactionBackups", "Flight_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoSalesTransactionBackups", "Flight_Date");
        }
    }
}
