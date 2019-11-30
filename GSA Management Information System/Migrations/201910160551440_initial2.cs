namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CargoSalesInformations");
            AlterColumn("dbo.CargoSalesInformations", "SalesSlno", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CargoSalesInformations", "SalesSlno");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CargoSalesInformations");
            AlterColumn("dbo.CargoSalesInformations", "SalesSlno", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CargoSalesInformations", "SalesSlno");
        }
    }
}
