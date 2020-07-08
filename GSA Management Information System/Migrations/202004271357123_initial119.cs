namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial119 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AccessListInformations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccessListInformations",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        BaseModule = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                    })
                .PrimaryKey(t => t.AccessId);
            
        }
    }
}
