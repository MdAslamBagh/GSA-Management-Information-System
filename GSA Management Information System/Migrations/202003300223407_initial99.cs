namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial99 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Code", c => c.String());
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Name", c => c.String());
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Address", c => c.String());
            AlterColumn("dbo.ConsignorInformations", "Consignor_Code", c => c.String());
            AlterColumn("dbo.ConsignorInformations", "Consignor_Name", c => c.String());
            AlterColumn("dbo.ConsignorInformations", "Consignor_Address", c => c.String());
            AlterColumn("dbo.ConsignorInformations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConsignorInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.ConsignorInformations", "Consignor_Address", c => c.String(nullable: false));
            AlterColumn("dbo.ConsignorInformations", "Consignor_Name", c => c.String(nullable: false));
            AlterColumn("dbo.ConsignorInformations", "Consignor_Code", c => c.String(nullable: false));
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Address", c => c.String(nullable: false));
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Name", c => c.String(nullable: false));
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Code", c => c.String(nullable: false));
        }
    }
}
