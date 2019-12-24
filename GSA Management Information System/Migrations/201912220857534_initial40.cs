namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Entry_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoSalesInformations", "Entry_Date");
        }
    }
}
