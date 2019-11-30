namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial18 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CargoSalesInformations", "Receivable_From_Agent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesInformations", "Receivable_From_Agent", c => c.Int(nullable: false));
        }
    }
}
