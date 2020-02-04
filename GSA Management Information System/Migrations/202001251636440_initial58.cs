namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial58 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportInformations", "ReportName", c => c.String());
            DropColumn("dbo.ReportInformations", "SubReportName");
            DropColumn("dbo.ReportInformations", "Entry_Date");
            DropTable("dbo.CargoSalesReports");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.ReportInformations", "Entry_Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReportInformations", "SubReportName", c => c.String());
            DropColumn("dbo.ReportInformations", "ReportName");
        }
    }
}
