namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial21 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccessInformation", newName: "AccessInformations");
            RenameTable(name: "dbo.AccessListInformation", newName: "AccessListInformations");
            RenameTable(name: "dbo.AirlinesInformation", newName: "AirlinesInformations");
            RenameTable(name: "dbo.BankInformation", newName: "BankInformations");
            RenameTable(name: "dbo.BaseModuleInformation", newName: "BaseModuleInformations");
            RenameTable(name: "dbo.CargoFreightPaymodeInformation", newName: "CargoFreightPaymodeInformations");
            RenameTable(name: "dbo.CargoSalesInformation", newName: "CargoSalesInformations");
            RenameTable(name: "dbo.CargoTypeInformation", newName: "CargoTypeInformations");
            RenameTable(name: "dbo.Category", newName: "Categories");
            RenameTable(name: "dbo.CityInformation", newName: "CityInformations");
            RenameTable(name: "dbo.CommonSetupInformation", newName: "CommonSetupInformations");
            RenameTable(name: "dbo.CompanyInformation", newName: "CompanyInformations");
            RenameTable(name: "dbo.ConsigneeInformation", newName: "ConsigneeInformations");
            RenameTable(name: "dbo.ConsignorInformation", newName: "ConsignorInformations");
            RenameTable(name: "dbo.ContinentInformation", newName: "ContinentInformations");
            RenameTable(name: "dbo.CountryInformation", newName: "CountryInformations");
            RenameTable(name: "dbo.CourierInboundSalesInformation", newName: "CourierInboundSalesInformations");
            RenameTable(name: "dbo.CourierOutboundSalesInformation", newName: "CourierOutboundSalesInformations");
            RenameTable(name: "dbo.CurrencyInformation", newName: "CurrencyInformations");
            RenameTable(name: "dbo.CustomerGroupInformation", newName: "CustomerGroupInformations");
            RenameTable(name: "dbo.CustomerInformation", newName: "CustomerInformations");
            RenameTable(name: "dbo.CustomerTypeInformation", newName: "CustomerTypeInformations");
            RenameTable(name: "dbo.DestinationInformation", newName: "DestinationInformations");
            RenameTable(name: "dbo.EditUserViewModel", newName: "EditUserViewModels");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.ExchangeInformation", newName: "ExchangeInformations");
            RenameTable(name: "dbo.FreighterInformation", newName: "FreighterInformations");
            RenameTable(name: "dbo.LoginInformation", newName: "LoginInformations");
            RenameTable(name: "dbo.MenuItemInformation", newName: "MenuItemInformations");
            RenameTable(name: "dbo.OriginInformation", newName: "OriginInformations");
            RenameTable(name: "dbo.PaymentModeInformation", newName: "PaymentModeInformations");
            RenameTable(name: "dbo.RouteInformation", newName: "RouteInformations");
            RenameTable(name: "dbo.StockIssueConfirmation", newName: "StockIssueConfirmations");
            RenameTable(name: "dbo.StockIssueInformation", newName: "StockIssueInformations");
            RenameTable(name: "dbo.StockRecieveInformation", newName: "StockRecieveInformations");
            RenameTable(name: "dbo.StockTypeInformation", newName: "StockTypeInformations");
            RenameTable(name: "dbo.SubMenuInformation", newName: "SubMenuInformations");
            RenameTable(name: "dbo.TicketSalesInformation", newName: "TicketSalesInformations");
            RenameTable(name: "dbo.UplimentTypeInformation", newName: "UplimentTypeInformations");
            RenameTable(name: "dbo.UserInformation", newName: "UserInformations");

        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserInformations", newName: "UserInformation");
            RenameTable(name: "dbo.UplimentTypeInformations", newName: "UplimentTypeInformation");
            RenameTable(name: "dbo.TicketSalesInformations", newName: "TicketSalesInformation");
            RenameTable(name: "dbo.SubMenuInformations", newName: "SubMenuInformation");
            RenameTable(name: "dbo.StockTypeInformations", newName: "StockTypeInformation");
            RenameTable(name: "dbo.StockRecieveInformations", newName: "StockRecieveInformation");
            RenameTable(name: "dbo.StockIssueInformations", newName: "StockIssueInformation");
            RenameTable(name: "dbo.StockIssueConfirmations", newName: "StockIssueConfirmation");
            RenameTable(name: "dbo.RouteInformations", newName: "RouteInformation");
            RenameTable(name: "dbo.PaymentModeInformations", newName: "PaymentModeInformation");
            RenameTable(name: "dbo.OriginInformations", newName: "OriginInformation");
            RenameTable(name: "dbo.MenuItemInformations", newName: "MenuItemInformation");
            RenameTable(name: "dbo.LoginInformations", newName: "LoginInformation");
            RenameTable(name: "dbo.FreighterInformations", newName: "FreighterInformation");
            RenameTable(name: "dbo.ExchangeInformations", newName: "ExchangeInformation");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            RenameTable(name: "dbo.EditUserViewModels", newName: "EditUserViewModel");
            RenameTable(name: "dbo.DestinationInformations", newName: "DestinationInformation");
            RenameTable(name: "dbo.CustomerTypeInformations", newName: "CustomerTypeInformation");
            RenameTable(name: "dbo.CustomerInformations", newName: "CustomerInformation");
            RenameTable(name: "dbo.CustomerGroupInformations", newName: "CustomerGroupInformation");
            RenameTable(name: "dbo.CurrencyInformations", newName: "CurrencyInformation");
            RenameTable(name: "dbo.CourierOutboundSalesInformations", newName: "CourierOutboundSalesInformation");
            RenameTable(name: "dbo.CourierInboundSalesInformations", newName: "CourierInboundSalesInformation");
            RenameTable(name: "dbo.CountryInformations", newName: "CountryInformation");
            RenameTable(name: "dbo.ContinentInformations", newName: "ContinentInformation");
            RenameTable(name: "dbo.ConsignorInformations", newName: "ConsignorInformation");
            RenameTable(name: "dbo.ConsigneeInformations", newName: "ConsigneeInformation");
            RenameTable(name: "dbo.CompanyInformations", newName: "CompanyInformation");
            RenameTable(name: "dbo.CommonSetupInformations", newName: "CommonSetupInformation");
            RenameTable(name: "dbo.CityInformations", newName: "CityInformation");
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.CargoTypeInformations", newName: "CargoTypeInformation");
            RenameTable(name: "dbo.CargoSalesInformations", newName: "CargoSalesInformation");
            RenameTable(name: "dbo.CargoFreightPaymodeInformations", newName: "CargoFreightPaymodeInformation");
            RenameTable(name: "dbo.BaseModuleInformations", newName: "BaseModuleInformation");
            RenameTable(name: "dbo.BankInformations", newName: "BankInformation");
            RenameTable(name: "dbo.AirlinesInformations", newName: "AirlinesInformation");
            RenameTable(name: "dbo.AccessListInformations", newName: "AccessListInformation");
            RenameTable(name: "dbo.AccessInformations", newName: "AccessInformation");

        }
    }
}
