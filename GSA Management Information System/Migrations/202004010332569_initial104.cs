namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial104 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockRecieveInformations", "Customer", c => c.String());
            AlterColumn("dbo.StockRecieveInformations", "SRecieved_Code", c => c.String());
            AlterColumn("dbo.StockRecieveInformations", "SR_Type", c => c.String());
            AlterColumn("dbo.StockRecieveInformations", "Issued", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockRecieveInformations", "Issued", c => c.String(nullable: false));
            AlterColumn("dbo.StockRecieveInformations", "SR_Type", c => c.String(nullable: false));
            AlterColumn("dbo.StockRecieveInformations", "SRecieved_Code", c => c.String(nullable: false));
            DropColumn("dbo.StockRecieveInformations", "Customer");
        }
    }
}
