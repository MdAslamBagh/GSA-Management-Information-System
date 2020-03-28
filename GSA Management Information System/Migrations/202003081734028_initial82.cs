namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial82 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketSalesInformations", "Payment_Mode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketSalesInformations", "Payment_Mode");
        }
    }
}
