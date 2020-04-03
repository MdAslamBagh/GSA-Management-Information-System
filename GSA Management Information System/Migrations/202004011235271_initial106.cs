namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial106 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockRecieveInformations", "Customer_Code", c => c.String(nullable: false));
            DropColumn("dbo.StockRecieveInformations", "Airlines");
            DropColumn("dbo.StockRecieveInformations", "Customer_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockRecieveInformations", "Customer_Name", c => c.String());
            AddColumn("dbo.StockRecieveInformations", "Airlines", c => c.String());
            AlterColumn("dbo.StockRecieveInformations", "Customer_Code", c => c.String());
        }
    }
}
