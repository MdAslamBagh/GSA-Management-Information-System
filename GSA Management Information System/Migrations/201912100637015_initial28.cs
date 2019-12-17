namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Payment_Code", c => c.String());
            DropColumn("dbo.CargoSalesInformations", "Payment_Mode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesInformations", "Payment_Mode", c => c.String());
            DropColumn("dbo.CargoSalesInformations", "Payment_Code");
        }
    }
}
