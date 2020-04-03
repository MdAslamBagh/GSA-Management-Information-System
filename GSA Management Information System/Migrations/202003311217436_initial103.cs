namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial103 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CountryInformations", "Long_Desc", c => c.String());
            AlterColumn("dbo.CountryInformations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CountryInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.CountryInformations", "Long_Desc", c => c.String(nullable: false));
        }
    }
}
