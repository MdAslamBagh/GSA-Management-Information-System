namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial105 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockRecieveInformations", "Customer_Name", c => c.String());
            DropColumn("dbo.StockRecieveInformations", "Customer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockRecieveInformations", "Customer", c => c.String());
            DropColumn("dbo.StockRecieveInformations", "Customer_Name");
        }
    }
}
