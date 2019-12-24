namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Flight_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoSalesInformations", "Flight_Date");
        }
    }
}
