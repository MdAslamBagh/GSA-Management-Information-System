namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial97 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerInformations", "Customer_Name", c => c.String());
            AlterColumn("dbo.CustomerInformations", "Group_Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerInformations", "Group_Code", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerInformations", "Customer_Name", c => c.String(nullable: false));
        }
    }
}
