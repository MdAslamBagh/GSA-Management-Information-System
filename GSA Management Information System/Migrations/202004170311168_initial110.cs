namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial110 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StockIssueInformations", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StockIssueInformations", "Remarks", c => c.String(nullable: false));
        }
    }
}
