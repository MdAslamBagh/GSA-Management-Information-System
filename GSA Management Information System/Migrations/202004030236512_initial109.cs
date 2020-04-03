namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial109 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PaymentModeInformations", "Payment_Mode", c => c.String());
            AlterColumn("dbo.PaymentModeInformations", "Long_Desc", c => c.String());
            AlterColumn("dbo.PaymentModeInformations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentModeInformations", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.PaymentModeInformations", "Long_Desc", c => c.String(nullable: false));
            AlterColumn("dbo.PaymentModeInformations", "Payment_Mode", c => c.String(nullable: false));
        }
    }
}
