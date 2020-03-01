namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial76 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockRecieveInformations", "CustomerInformation_CustomerId", "dbo.CustomerInformations");
            DropIndex("dbo.StockRecieveInformations", new[] { "CustomerInformation_CustomerId" });
            DropColumn("dbo.StockRecieveInformations", "Customer_Code");
            DropColumn("dbo.StockRecieveInformations", "CustomerInformation_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockRecieveInformations", "CustomerInformation_CustomerId", c => c.Int());
            AddColumn("dbo.StockRecieveInformations", "Customer_Code", c => c.String());
            CreateIndex("dbo.StockRecieveInformations", "CustomerInformation_CustomerId");
            AddForeignKey("dbo.StockRecieveInformations", "CustomerInformation_CustomerId", "dbo.CustomerInformations", "CustomerId");
        }
    }
}
