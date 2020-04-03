namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial100 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Address", c => c.String(nullable: false));
            AlterColumn("dbo.ConsignorInformations", "Consignor_Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConsignorInformations", "Consignor_Address", c => c.String());
            AlterColumn("dbo.ConsigneeInformations", "Consignee_Address", c => c.String());
        }
    }
}
