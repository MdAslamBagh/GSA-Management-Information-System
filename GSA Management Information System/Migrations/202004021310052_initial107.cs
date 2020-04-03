namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial107 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportInformations", "Entry_Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportInformations", "Entry_Date");
        }
    }
}
