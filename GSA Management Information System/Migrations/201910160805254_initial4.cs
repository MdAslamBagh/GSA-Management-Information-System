namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CargoSalesInformations", "Exchange_Rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CargoSalesInformations", "Exchange_Rate", c => c.Int(nullable: false));
        }
    }
}
