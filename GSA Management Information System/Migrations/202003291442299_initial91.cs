namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial91 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerInformations", "Customer_Code", c => c.String());
            AlterColumn("dbo.CustomerInformations", "City_Code", c => c.String());
            AlterColumn("dbo.CustomerInformations", "Contact_No", c => c.String());
            DropColumn("dbo.CustomerInformations", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerInformations", "Contact_No", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerInformations", "City_Code", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerInformations", "Customer_Code", c => c.String(nullable: false));
        }
    }
}
