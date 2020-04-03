namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial92 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerInformations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerInformations", "Status");
        }
    }
}
