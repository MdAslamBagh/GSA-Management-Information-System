namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial114 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailContentInformations",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        To = c.String(),
                        Cc = c.String(),
                        Bcc = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        HostServer = c.String(),
                        UserEmail = c.String(),
                        UserPassword = c.String(),
                        SmtpPort = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.EmailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailContentInformations");
        }
    }
}
