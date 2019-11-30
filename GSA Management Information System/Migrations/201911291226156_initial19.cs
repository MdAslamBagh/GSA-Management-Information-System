namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial19 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CargoSalesInformations", "Flight_Date");
            DropColumn("dbo.CargoSalesInformations", "Entry_Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesInformations", "Entry_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.CargoSalesInformations", "Flight_Date", c => c.DateTime(nullable: false));
        }
    }
}
