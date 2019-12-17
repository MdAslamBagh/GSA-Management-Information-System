namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoSalesTransactionBackups", "Trans_Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoSalesTransactionBackups", "Trans_Type");
        }
    }
}
