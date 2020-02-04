namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial59 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoSalesReports",
                c => new
                    {
                        CargoSalesReportId = c.Int(nullable: false, identity: true),
                        SubMenuId = c.Int(nullable: false),
                        MAWB = c.String(),
                        Airway_No = c.String(),
                    })
                .PrimaryKey(t => t.CargoSalesReportId);
            
            AddColumn("dbo.ReportInformations", "SubReportName", c => c.String());
            AddColumn("dbo.ReportInformations", "Entry_Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReportInformations", "ReportName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportInformations", "ReportName", c => c.String());
            DropColumn("dbo.ReportInformations", "Entry_Date");
            DropColumn("dbo.ReportInformations", "SubReportName");
            DropTable("dbo.CargoSalesReports");
        }
    }
}
