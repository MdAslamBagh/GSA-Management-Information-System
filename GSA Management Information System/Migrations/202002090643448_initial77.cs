namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial77 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockRecieveInformations", "Customer_Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockRecieveInformations", "Customer_Code");
        }
    }
}
