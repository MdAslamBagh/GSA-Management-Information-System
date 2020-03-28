namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial87 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CargoDueReceipts", "MAWB", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CargoDueReceipts", "MAWB");
        }
    }
}
