namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial96 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerGroupInformations", "Group_Code", c => c.String());
            AlterColumn("dbo.CustomerGroupInformations", "Long_Desc", c => c.String());
            AlterColumn("dbo.CustomerGroupInformations", "Status", c => c.String());
            AlterColumn("dbo.CustomerTypeInformations", "Type_Code", c => c.String());
            AlterColumn("dbo.CustomerTypeInformations", "Long_Desc", c => c.String());
            AlterColumn("dbo.CustomerTypeInformations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerTypeInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerTypeInformations", "Long_Desc", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerTypeInformations", "Type_Code", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerGroupInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerGroupInformations", "Long_Desc", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerGroupInformations", "Group_Code", c => c.String(nullable: false));
        }
    }
}
