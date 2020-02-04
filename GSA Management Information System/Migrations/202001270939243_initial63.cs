namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial63 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.StockIssueConfirmations");
            DropTable("dbo.UserInformations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserRoles = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phoneno = c.String(),
                        Company_Code = c.String(),
                        Branch_Code = c.String(),
                        Password = c.String(),
                        Confirm_Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.StockIssueConfirmations",
                c => new
                    {
                        CIssueId = c.Int(nullable: false, identity: true),
                        SIssued_Code = c.String(),
                        Airlines_Code = c.Int(nullable: false),
                        From_TicketNo = c.Int(nullable: false),
                        To_TicketNo = c.Int(nullable: false),
                        Ticket_Quantity = c.Int(nullable: false),
                        Customer_Code = c.String(),
                        Remarks = c.String(),
                        Status = c.String(),
                        Confirm_Date = c.DateTime(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.CIssueId);
            
        }
    }
}
