namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initisl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CargoSalesInformations", "Airlines_Code");
            DropColumn("dbo.CargoSalesInformations", "Payable_Agent_CC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesInformations", "Payable_Agent_CC", c => c.Single(nullable: false));
            AddColumn("dbo.CargoSalesInformations", "Airlines_Code", c => c.Int(nullable: false));
        }
    }
}
