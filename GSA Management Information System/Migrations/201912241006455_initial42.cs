namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial42 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StockRecieveInformations", "Transaction_Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockRecieveInformations", "Transaction_Status", c => c.String(nullable: false));
        }
    }
}
