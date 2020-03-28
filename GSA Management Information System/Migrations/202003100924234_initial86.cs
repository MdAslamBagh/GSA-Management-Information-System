namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial86 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDueReceipts",
                c => new
                    {
                        CargoDueReceiptId = c.Int(nullable: false, identity: true),
                        SalesSlno = c.Int(nullable: false),
                        Airway_No = c.String(),
                        Customer_Code = c.String(),
                        Document_Type = c.String(),
                        Receipt_No = c.String(),
                        Receipt_Date = c.DateTime(nullable: false),
                        Receipt_Amount = c.Single(nullable: false),
                        Remarks = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.CargoDueReceiptId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoDueReceipts");
        }
    }
}
