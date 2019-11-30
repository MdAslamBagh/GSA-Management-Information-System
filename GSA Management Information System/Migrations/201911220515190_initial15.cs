namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EditUserViewModels", "Email", c => c.String());
            AlterColumn("dbo.EditUserViewModels", "Password", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EditUserViewModels", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EditUserViewModels", "Email", c => c.String(nullable: false));
        }
    }
}
