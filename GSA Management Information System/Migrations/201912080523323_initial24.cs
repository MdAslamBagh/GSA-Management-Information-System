namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankInformations", "Entry_By", c => c.String());
            AddColumn("dbo.Cargo_Debit_Credit_Note", "Entry_By", c => c.String());
            AddColumn("dbo.CargoFreightPaymodeInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CargoSalesInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CargoTypeInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CityInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CommonSetupInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CompanyInformations", "Entry_By", c => c.String());
            AddColumn("dbo.ConsignorInformations", "Entry_By", c => c.String());
            AddColumn("dbo.ContinentInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CountryInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CourierInboundSalesInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CourierOutboundSalesInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CurrencyInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CustomerGroupInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CustomerInformations", "Entry_By", c => c.String());
            AddColumn("dbo.CustomerTypeInformations", "Entry_By", c => c.String());
            AddColumn("dbo.DestinationInformations", "Entry_By", c => c.String());
            AddColumn("dbo.ExchangeInformations", "Entry_By", c => c.String());
            AddColumn("dbo.FreighterInformations", "Entry_By", c => c.String());
            AddColumn("dbo.MenuItemInformations", "Entry_By", c => c.String());
            AddColumn("dbo.OriginInformations", "Entry_By", c => c.String());
            AddColumn("dbo.PaymentModeInformations", "Entry_By", c => c.String());
            AddColumn("dbo.RouteInformations", "Entry_By", c => c.String());
            AddColumn("dbo.StockIssueConfirmations", "Entry_By", c => c.String());
            AddColumn("dbo.StockIssueInformations", "Entry_By", c => c.String());
            AddColumn("dbo.StockRecieveInformations", "Entry_By", c => c.String());
            AddColumn("dbo.StockTypeInformations", "Entry_By", c => c.String());
            AddColumn("dbo.SubMenuInformations", "Entry_By", c => c.String());
            AddColumn("dbo.TicketSalesInformations", "Entry_By", c => c.String());
            AddColumn("dbo.UplimentTypeInformations", "Entry_By", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UplimentTypeInformations", "Entry_By");
            DropColumn("dbo.TicketSalesInformations", "Entry_By");
            DropColumn("dbo.SubMenuInformations", "Entry_By");
            DropColumn("dbo.StockTypeInformations", "Entry_By");
            DropColumn("dbo.StockRecieveInformations", "Entry_By");
            DropColumn("dbo.StockIssueInformations", "Entry_By");
            DropColumn("dbo.StockIssueConfirmations", "Entry_By");
            DropColumn("dbo.RouteInformations", "Entry_By");
            DropColumn("dbo.PaymentModeInformations", "Entry_By");
            DropColumn("dbo.OriginInformations", "Entry_By");
            DropColumn("dbo.MenuItemInformations", "Entry_By");
            DropColumn("dbo.FreighterInformations", "Entry_By");
            DropColumn("dbo.ExchangeInformations", "Entry_By");
            DropColumn("dbo.DestinationInformations", "Entry_By");
            DropColumn("dbo.CustomerTypeInformations", "Entry_By");
            DropColumn("dbo.CustomerInformations", "Entry_By");
            DropColumn("dbo.CustomerGroupInformations", "Entry_By");
            DropColumn("dbo.CurrencyInformations", "Entry_By");
            DropColumn("dbo.CourierOutboundSalesInformations", "Entry_By");
            DropColumn("dbo.CourierInboundSalesInformations", "Entry_By");
            DropColumn("dbo.CountryInformations", "Entry_By");
            DropColumn("dbo.ContinentInformations", "Entry_By");
            DropColumn("dbo.ConsignorInformations", "Entry_By");
            DropColumn("dbo.CompanyInformations", "Entry_By");
            DropColumn("dbo.CommonSetupInformations", "Entry_By");
            DropColumn("dbo.CityInformations", "Entry_By");
            DropColumn("dbo.CargoTypeInformations", "Entry_By");
            DropColumn("dbo.CargoSalesInformations", "Entry_By");
            DropColumn("dbo.CargoFreightPaymodeInformations", "Entry_By");
            DropColumn("dbo.Cargo_Debit_Credit_Note", "Entry_By");
            DropColumn("dbo.BankInformations", "Entry_By");
        }
    }
}
