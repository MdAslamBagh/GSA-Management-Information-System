namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial52 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportInformations", "SubReportName", c => c.String());
            DropColumn("dbo.ReportInformations", "ReportName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportInformations", "ReportName", c => c.String());
            DropColumn("dbo.ReportInformations", "SubReportName");
        }
    }
}
