namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial78 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestinationInformations", "Continent_Code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DestinationInformations", "Continent_Code");
        }
    }
}
