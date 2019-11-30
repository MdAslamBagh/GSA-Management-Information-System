namespace GSA_Management_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.AirlinesInformations",
                c => new
                    {
                        AirlinesId = c.Int(nullable: false, identity: true),
                        Airlines_Code = c.Int(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.AirlinesId);
            
            CreateTable(
                "dbo.BankInformations",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        Bank_Code = c.Int(nullable: false),
                        Long_Desc = c.String(),
                        Status = c.String(),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.BaseModuleInformations",
                c => new
                    {
                        BaseModuleId = c.Int(nullable: false, identity: true),
                        BaseModule = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                        Entry_By = c.String(),
                    })
                .PrimaryKey(t => t.BaseModuleId);
            
            CreateTable(
                "dbo.Cargo_Debit_Credit_Note",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Trans_Date = c.DateTime(nullable: false),
                        Type = c.String(),
                        Customer_Name = c.String(),
                        Reference_No = c.String(),
                        Currency = c.Int(nullable: false),
                        Exchange_Rate = c.Single(nullable: false),
                        Amount_USD = c.Single(nullable: false),
                        Amount_BDT = c.Single(nullable: false),
                        Remarks = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CargoFreightPaymodeInformations",
                c => new
                    {
                        CFPaymodeId = c.Int(nullable: false, identity: true),
                        CFPaymode_Code = c.Int(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CFPaymodeId);
            
            CreateTable(
                "dbo.CargoSalesInformations",
                c => new
                    {
                        SalesSlno = c.String(nullable: false, maxLength: 128),
                        MAWB = c.String(),
                        Check_Digit = c.String(),
                        Flight_Date = c.DateTime(nullable: false),
                        Airlines_Code = c.Int(nullable: false),
                        Airway_No = c.String(),
                        Freighter_Code = c.Int(nullable: false),
                        Origin_Code = c.String(),
                        Dest_Code = c.String(),
                        Continent_Code = c.Int(nullable: false),
                        Payment_Mode = c.String(),
                        CFPaymode_Code = c.Int(nullable: false),
                        Route_Code = c.String(),
                        Customer_Code = c.String(),
                        Cargo_Code = c.String(),
                        UType_Code = c.Int(nullable: false),
                        HDS = c.Int(nullable: false),
                        AMS = c.Int(nullable: false),
                        Gross_Weight = c.Int(nullable: false),
                        Chargeable_Weight = c.Int(nullable: false),
                        Rate_Charge = c.Int(nullable: false),
                        B_Rate = c.Int(nullable: false),
                        AIT = c.Int(nullable: false),
                        Agent_Commission = c.Int(nullable: false),
                        HBL_Qty = c.Int(nullable: false),
                        Others = c.Int(nullable: false),
                        THC = c.Int(nullable: false),
                        SSC = c.Int(nullable: false),
                        FSC_Charge = c.Int(nullable: false),
                        ISS_Charge = c.Int(nullable: false),
                        SSC_VAT = c.Int(nullable: false),
                        Total_USD = c.Int(nullable: false),
                        Total_SSC = c.Int(nullable: false),
                        Consignee_Code = c.String(),
                        Consignor_Code = c.String(),
                        Receivable_From_Agent = c.Int(nullable: false),
                        Remarks = c.String(),
                        Currency = c.String(),
                        Exchange_Rate = c.Int(nullable: false),
                        Receivable_Amount_BDT = c.Int(nullable: false),
                        Payable_Agent_CC = c.Int(nullable: false),
                        Remarks_B_Bank = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesSlno);
            
            CreateTable(
                "dbo.CargoTypeInformations",
                c => new
                    {
                        CargoTypeId = c.Int(nullable: false, identity: true),
                        Cargo_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTypeId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatagoryId = c.Int(nullable: false, identity: true),
                        CategoryCode = c.Int(nullable: false),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CatagoryId);
            
            CreateTable(
                "dbo.CityInformations",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        City_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Country_Code = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.CommonSetupInformations",
                c => new
                    {
                        CommonId = c.Int(nullable: false, identity: true),
                        SerialNo = c.Int(nullable: false),
                        Particulars = c.String(),
                        Description = c.String(),
                        Particular_Value = c.Double(nullable: false),
                        Minimum_Value = c.Double(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommonId);
            
            CreateTable(
                "dbo.CompanyInformations",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(nullable: false),
                        Company_Code = c.String(nullable: false),
                        Branch_Name = c.String(nullable: false),
                        Branch_Code = c.String(nullable: false),
                        Company_Tin = c.String(nullable: false),
                        Company_Address = c.String(nullable: false),
                        Company_Postcode = c.String(nullable: false),
                        Company_City = c.String(nullable: false),
                        Company_Country = c.String(nullable: false),
                        Company_ContacNo = c.String(),
                        Company_Fax = c.String(),
                        Company_Email = c.String(),
                        Company_Web = c.String(),
                        Company_Dialogue = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                        Company_ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.ConsigneeInformations",
                c => new
                    {
                        ConsigneeId = c.Int(nullable: false, identity: true),
                        Consignee_Code = c.String(nullable: false),
                        Consignee_Name = c.String(nullable: false),
                        Consignee_Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConsigneeId);
            
            CreateTable(
                "dbo.ConsignorInformations",
                c => new
                    {
                        ConsignorId = c.Int(nullable: false, identity: true),
                        Consignor_Code = c.String(nullable: false),
                        Consignor_Name = c.String(nullable: false),
                        Consignor_Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConsignorId);
            
            CreateTable(
                "dbo.ContinentInformations",
                c => new
                    {
                        ContinentId = c.Int(nullable: false, identity: true),
                        Continent_Code = c.Int(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        FSC_Charge = c.Single(nullable: false),
                        ISS_Charge = c.Single(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContinentId);
            
            CreateTable(
                "dbo.CountryInformations",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Continent_Code = c.Int(nullable: false),
                        Country_Code = c.Int(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.CourierInboundSalesInformations",
                c => new
                    {
                        SalesSlno = c.String(nullable: false, maxLength: 128),
                        MAWB = c.String(),
                        Check_Digit = c.String(),
                        Flight_Date = c.DateTime(nullable: false),
                        Airlines_Code = c.Int(nullable: false),
                        Airway_No = c.String(),
                        Freighter_Code = c.Int(nullable: false),
                        Origin_Code = c.String(),
                        Dest_Code = c.String(),
                        Continent_Code = c.Int(nullable: false),
                        Payment_Mode = c.String(),
                        CFPaymode_Code = c.Int(nullable: false),
                        Route_Code = c.String(),
                        Customer_Code = c.String(),
                        Cargo_Code = c.String(),
                        UType_Code = c.Int(nullable: false),
                        HDS = c.Int(nullable: false),
                        AMS = c.Int(nullable: false),
                        Gross_Weight = c.Int(nullable: false),
                        Chargeable_Weight = c.Int(nullable: false),
                        Rate_Charge = c.Int(nullable: false),
                        B_Rate = c.Int(nullable: false),
                        AIT = c.Int(nullable: false),
                        Agent_Commission = c.Int(nullable: false),
                        HBL_Qty = c.Int(nullable: false),
                        Others = c.Int(nullable: false),
                        THC = c.Int(nullable: false),
                        SSC = c.Int(nullable: false),
                        FSC_Charge = c.Int(nullable: false),
                        ISS_Charge = c.Int(nullable: false),
                        SSC_VAT = c.Int(nullable: false),
                        Total_USD = c.Int(nullable: false),
                        Total_SSC = c.Int(nullable: false),
                        Consignee_Code = c.String(),
                        Consignor_Code = c.String(),
                        Receivable_From_Agent = c.Int(nullable: false),
                        Remarks = c.String(),
                        Currency = c.String(),
                        Exchange_Rate = c.Int(nullable: false),
                        Receivable_Amount_BDT = c.Int(nullable: false),
                        Payable_Agent_CC = c.Int(nullable: false),
                        Remarks_B_Bank = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesSlno);
            
            CreateTable(
                "dbo.CourierOutboundSalesInformations",
                c => new
                    {
                        SalesSlno = c.String(nullable: false, maxLength: 128),
                        MAWB = c.String(),
                        Check_Digit = c.String(),
                        Flight_Date = c.DateTime(nullable: false),
                        Airlines_Code = c.Int(nullable: false),
                        Airway_No = c.String(),
                        Freighter_Code = c.Int(nullable: false),
                        Origin_Code = c.String(),
                        Dest_Code = c.String(),
                        Continent_Code = c.Int(nullable: false),
                        Payment_Mode = c.String(),
                        CFPaymode_Code = c.Int(nullable: false),
                        Route_Code = c.String(),
                        Customer_Code = c.String(),
                        Cargo_Code = c.String(),
                        UType_Code = c.Int(nullable: false),
                        HDS = c.Int(nullable: false),
                        AMS = c.Int(nullable: false),
                        Gross_Weight = c.Int(nullable: false),
                        Chargeable_Weight = c.Int(nullable: false),
                        Rate_Charge = c.Int(nullable: false),
                        B_Rate = c.Int(nullable: false),
                        AIT = c.Int(nullable: false),
                        Agent_Commission = c.Int(nullable: false),
                        HBL_Qty = c.Int(nullable: false),
                        Others = c.Int(nullable: false),
                        THC = c.Int(nullable: false),
                        SSC = c.Int(nullable: false),
                        FSC_Charge = c.Int(nullable: false),
                        ISS_Charge = c.Int(nullable: false),
                        SSC_VAT = c.Int(nullable: false),
                        Total_USD = c.Int(nullable: false),
                        Total_SSC = c.Int(nullable: false),
                        Consignee_Code = c.String(),
                        Consignor_Code = c.String(),
                        Receivable_From_Agent = c.Int(nullable: false),
                        Remarks = c.String(),
                        Currency = c.String(),
                        Exchange_Rate = c.Int(nullable: false),
                        Receivable_Amount_BDT = c.Int(nullable: false),
                        Payable_Agent_CC = c.Int(nullable: false),
                        Remarks_B_Bank = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesSlno);
            
            CreateTable(
                "dbo.CurrencyInformations",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        Currency_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Short_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.CustomerGroupInformations",
                c => new
                    {
                        CustomerGroupId = c.Int(nullable: false, identity: true),
                        Group_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerGroupId);
            
            CreateTable(
                "dbo.CustomerInformations",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Customer_Code = c.String(nullable: false),
                        Bp_Code = c.Int(nullable: false),
                        Customer_Name = c.String(nullable: false),
                        Type_Code = c.String(),
                        Group_Code = c.String(nullable: false),
                        Address = c.String(),
                        Country_Code = c.Int(nullable: false),
                        City_Code = c.String(nullable: false),
                        Contact_No = c.String(nullable: false),
                        Fax = c.String(),
                        Email = c.String(),
                        Web = c.String(),
                        Contact_Person = c.String(),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerTypeInformations",
                c => new
                    {
                        CustomerTypeId = c.Int(nullable: false, identity: true),
                        Type_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.DestinationInformations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        Country_Code = c.Int(nullable: false),
                        Dest_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        ToDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ExchangeInformations",
                c => new
                    {
                        ExchangeId = c.Int(nullable: false, identity: true),
                        Currency_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Exchange_Rate = c.Single(nullable: false),
                        Status = c.String(),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExchangeId);
            
            CreateTable(
                "dbo.FreighterInformations",
                c => new
                    {
                        FreighterId = c.Int(nullable: false, identity: true),
                        Freighter_Code = c.Int(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FreighterId);
            
            CreateTable(
                "dbo.LoginInformations",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.OriginInformations",
                c => new
                    {
                        OriginId = c.Int(nullable: false, identity: true),
                        Origin_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OriginId);
            
            CreateTable(
                "dbo.PaymentModeInformations",
                c => new
                    {
                        PaymentModeId = c.Int(nullable: false, identity: true),
                        Payment_Code = c.Int(nullable: false),
                        Payment_Mode = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentModeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RouteInformations",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        Route_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Type_Code = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId);
            
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
                    })
                .PrimaryKey(t => t.CIssueId);
            
            CreateTable(
                "dbo.StockIssueDetailInformations",
                c => new
                    {
                        SDetailsId = c.Int(nullable: false, identity: true),
                        SIssued_Code = c.String(),
                        Ticket_No = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.SDetailsId);
            
            CreateTable(
                "dbo.StockIssueInformations",
                c => new
                    {
                        SIssueId = c.Int(nullable: false, identity: true),
                        SIssued_Code = c.String(nullable: false),
                        SRecieved_Code = c.String(nullable: false),
                        Stock_Type = c.String(),
                        Issue_Date = c.DateTime(nullable: false),
                        Airlines_Code = c.Int(nullable: false),
                        From_TicketNo = c.Int(nullable: false),
                        To_TicketNo = c.Int(nullable: false),
                        Ticket_Quantity = c.Int(nullable: false),
                        Customer_Code = c.String(nullable: false),
                        Remarks = c.String(nullable: false),
                        Transaction_Status = c.String(),
                        Confirm_Status = c.String(),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SIssueId);
            
            CreateTable(
                "dbo.StockRecieveInformations",
                c => new
                    {
                        SRecievedId = c.Int(nullable: false, identity: true),
                        SRecieved_Code = c.String(nullable: false),
                        SR_Type = c.String(nullable: false),
                        Trans_Date = c.DateTime(nullable: false),
                        Airlines_Code = c.Int(nullable: false),
                        From_TicketNo = c.Int(nullable: false),
                        To_TicketNo = c.Int(nullable: false),
                        Ticket_Quantity = c.Int(nullable: false),
                        Customer_Code = c.String(),
                        Remarks = c.String(),
                        Transaction_Status = c.String(nullable: false),
                        Issued = c.String(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                        CustomerInformation_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.SRecievedId)
                .ForeignKey("dbo.CustomerInformations", t => t.CustomerInformation_CustomerId)
                .Index(t => t.CustomerInformation_CustomerId);
            
            CreateTable(
                "dbo.StockTypeInformations",
                c => new
                    {
                        STypeId = c.Int(nullable: false, identity: true),
                        SType_Code = c.String(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Short_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.STypeId);
            
            CreateTable(
                "dbo.TicketSalesInformations",
                c => new
                    {
                        TicketSalesId = c.Int(nullable: false, identity: true),
                        Sales_Slno = c.Int(nullable: false),
                        Airlines_Code = c.Int(nullable: false),
                        Ticket_Date = c.DateTime(nullable: false),
                        Ticket_No = c.Int(nullable: false),
                        Customer_Code = c.String(),
                        Bank_Code = c.Int(nullable: false),
                        Exchange_Rate = c.Single(nullable: false),
                        Sales_Value_USD = c.Int(nullable: false),
                        Sales_Value_BDT = c.Single(nullable: false),
                        Commison = c.Int(nullable: false),
                        Commison_Amount = c.Single(nullable: false),
                        Emb_Tax = c.Int(nullable: false),
                        Travel_Tax = c.Int(nullable: false),
                        Fuel_Charge = c.Int(nullable: false),
                        Hk_Tax = c.Int(nullable: false),
                        Xt_Charge = c.Int(nullable: false),
                        Other_Charge = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Net_Receivable_Amount = c.Single(nullable: false),
                        Received_Amount = c.Int(nullable: false),
                        Amount_In_PPRS = c.Single(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.TicketSalesId);
            
            CreateTable(
                "dbo.UplimentTypeInformations",
                c => new
                    {
                        UTypeId = c.Int(nullable: false, identity: true),
                        UType_Code = c.Int(nullable: false),
                        Long_Desc = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Default_Code = c.Boolean(nullable: false),
                        Entry_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UTypeId);
            
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
                        Password = c.String(),
                        Confirm_Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.String(),
                        Status = c.String(),
                        FullName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockRecieveInformations", "CustomerInformation_CustomerId", "dbo.CustomerInformations");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StockRecieveInformations", new[] { "CustomerInformation_CustomerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserInformations");
            DropTable("dbo.UplimentTypeInformations");
            DropTable("dbo.TicketSalesInformations");
            DropTable("dbo.StockTypeInformations");
            DropTable("dbo.StockRecieveInformations");
            DropTable("dbo.StockIssueInformations");
            DropTable("dbo.StockIssueDetailInformations");
            DropTable("dbo.StockIssueConfirmations");
            DropTable("dbo.RouteInformations");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PaymentModeInformations");
            DropTable("dbo.OriginInformations");
            DropTable("dbo.LoginInformations");
            DropTable("dbo.FreighterInformations");
            DropTable("dbo.ExchangeInformations");
            DropTable("dbo.Employees");
            DropTable("dbo.DestinationInformations");
            DropTable("dbo.CustomerTypeInformations");
            DropTable("dbo.CustomerInformations");
            DropTable("dbo.CustomerGroupInformations");
            DropTable("dbo.CurrencyInformations");
            DropTable("dbo.CourierOutboundSalesInformations");
            DropTable("dbo.CourierInboundSalesInformations");
            DropTable("dbo.CountryInformations");
            DropTable("dbo.ContinentInformations");
            DropTable("dbo.ConsignorInformations");
            DropTable("dbo.ConsigneeInformations");
            DropTable("dbo.CompanyInformations");
            DropTable("dbo.CommonSetupInformations");
            DropTable("dbo.CityInformations");
            DropTable("dbo.Categories");
            DropTable("dbo.CargoTypeInformations");
            DropTable("dbo.CargoSalesInformations");
            DropTable("dbo.CargoFreightPaymodeInformations");
            DropTable("dbo.Cargo_Debit_Credit_Note");
            DropTable("dbo.BaseModuleInformations");
            DropTable("dbo.BankInformations");
            DropTable("dbo.AirlinesInformations");
            DropTable("dbo.AccessListInformations");
        }
    }
}
