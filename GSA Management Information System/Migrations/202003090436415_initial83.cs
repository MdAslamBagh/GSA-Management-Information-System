namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial83 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketSalesInformations", "IsExported", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketSalesInformations", "IsExported");
        }
    }
}
