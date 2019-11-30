namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesInformations", "Currency_Code", c => c.String());
            DropColumn("dbo.CargoSalesInformations", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoSalesInformations", "Currency", c => c.String());
            DropColumn("dbo.CargoSalesInformations", "Currency_Code");
        }
    }
}
