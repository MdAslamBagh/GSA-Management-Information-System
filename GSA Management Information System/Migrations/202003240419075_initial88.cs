namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial88 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CargoDueReceipts", "MAWB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CargoDueReceipts", "MAWB", c => c.String());
        }
    }
}
