namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CargoSalesInformations");
            AddColumn("dbo.CargoSalesInformations", "CargoSalesId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CargoSalesInformations", "SalesSlno", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CargoSalesInformations", "CargoSalesId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CargoSalesInformations");
            AlterColumn("dbo.CargoSalesInformations", "SalesSlno", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.CargoSalesInformations", "CargoSalesId");
            AddPrimaryKey("dbo.CargoSalesInformations", "SalesSlno");
        }
    }
}
