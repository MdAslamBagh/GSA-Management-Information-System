namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial102 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExchangeInformations", "Currency_Code", c => c.String());
            AlterColumn("dbo.ExchangeInformations", "Long_Desc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExchangeInformations", "Long_Desc", c => c.String(nullable: false));
            AlterColumn("dbo.ExchangeInformations", "Currency_Code", c => c.String(nullable: false));
        }
    }
}
