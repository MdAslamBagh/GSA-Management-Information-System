namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial66 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConsigneeInformations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConsigneeInformations", "Status", c => c.String(nullable: false));
        }
    }
}
