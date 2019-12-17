namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConsigneeInformations", "Entry_By", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConsigneeInformations", "Entry_By");
        }
    }
}
