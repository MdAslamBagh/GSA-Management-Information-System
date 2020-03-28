 --if master date select then Entry Date wise
 --if flight date select then Flight Date Wise

 --//EntryDate/Master Date Command
 EXEC spCargoSalesDetailsByMasterEntryDate @From_Date = '2020-01-16 17:38:35.000', @To_Date = '2020-01-18 17:38:35.000'
 
 
 --//Flight Date Wise Command

  exce vwCargoSalesDetails @From_Date = '2020-01-15 00:00:00.000', @To_Date = '2020-02-18 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null,



    --   WHERE
	   --cargo.Entry_Date BETWEEN '2020-02-25' AND '2020-02-27'  
	   --and cargotype.Long_Desc between 'ART WORK' and 'Garments' 
	   --and customer.Group_Code between 'CASS' and 'NON-CASS'
   
	   --   WHERE
	   --cargo.Entry_Date BETWEEN '2020-02-25' AND '2020-02-27'  
	   --and cargotype.Long_Desc between 'ART WORK' and 'Garments' 
	   --and (customer.Group_Code  like '%CASS%' OR  customer.Group_Code like '%NON-CASS%' )
	   --RIGHT

	   --Entry Date Wise
	   	 Execute vwCargoSalesDetails @From_Date = '2020-02-25 00:00:00.000', @To_Date = '2020-03-27 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null
		-- Flight Date Wise
		 Execute vwCargoSalesDetails @Flight_From_Date = '2020-02-25 00:00:00.000', @Flight_To_Date = '2020-03-27 00:00:00.000',@From_Date=null,@To_Date=null


	   --CargoType Entry Date wise
	 Execute vwCargoSalesDetails @From_Date = '2020-02-25 00:00:00.000', @To_Date = '2020-03-27 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null,@CargoType_From_Item='%%',@CargoType_To_Item='%%',@Group_From_Item= '%%',@Group_To_Item='%%'
		 
		 --CargoType Flight Date Wise
	 Execute vwCargoSalesDetails @Flight_From_Date = '2020-02-25 00:00:00.000', @Flight_To_Date = '2020-02-27 00:00:00.000',@From_Date=null,@To_Date=null,@CargoType_From_Item='Garments',@CargoType_To_Item='Garments',@Group_From_Item= 'CASS',@Group_To_Item='NON-CASS'


		--right freighter entry date wise
	   Execute vwCargoSalesDetails @Flight_From_Date = '2020-02-25 00:00:00.000', @Flight_To_Date = '2020-02-27 00:00:00.000',@From_Date=null,@To_Date=null,@FreighterType_From_Item='CX 2046',@FreighterType_To_Item='CX 2046'

	 

		      Execute vwCargoSalesDetails @From_Date = '2020-02-25 00:00:00.000', @To_Date = '2020-02-27 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null,@FreighterType_From_Item='CX 2046',@FreighterType_To_Item='CX 2046',@Group_From_Item= 'CASS',@Group_To_Item='Non-CASS'

		 --Destination wise entry date
		 Execute vwCargoSalesDetails @From_Date = '2020-02-25 00:00:00.000', @To_Date = '2020-02-27 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null,@Destination_From_Item='Dhaka',@Destination_To_Item='Dhaka',@Group_From_Item= '%%',@Group_To_Item='%%'
		 --continent wise
		 
		 Execute vwCargoSalesDetails @From_Date = '2020-02-25 00:00:00.000', @To_Date = '2020-02-27 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null,@Destination='kashmir',@Destination_From_Item='%%',@Destination_To_Item='%%',@Group_From_Item= '%%',@Group_To_Item='%%'

	      Execute vwCargoSalesDetails @From_Date = '2020-02-25 00:00:00.000', @To_Date = '2020-02-27 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null,@FreighterType_From_Item='%%',@FreighterType_To_Item='%%',@Region='Dhaka',@Country='%%',@Destination='%%',@Destination_From_Item='%%',@Destination_To_Item='%%',@Group_From_Item= '%%',@Group_To_Item='%%'



--//Create Procedure command start
 -- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spCargoSalesDetailsByFlightDate 
	-- Add the parameters for the stored procedure here
	 @From_Date datetime,
     @To_Date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM CargoSalesInformations
WHERE Flight_Date BETWEEN @From_Date AND @To_Date; 
END
GO
 --//End 


 --Right Procedure
 USE [GSAMISDB]
GO
/****** Object:  StoredProcedure [dbo].[vwCargoSalesDetails]    Script Date: 2/12/2020 8:57:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[vwCargoSalesDetails]
	-- Add the parameters for the stored procedure here
             @From_Date datetime,
             @To_Date datetime,
	         @Flight_From_Date datetime,
	         @Flight_To_Date datetime,
			 @CargoType varchar(90)='%',
			 @FreighterType varchar(90)='%',
			 @CustomerName varchar(90)='%',			 
			 @From_Item varchar,
			 @To_Item varchar 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Cargo.CargoSalesId,cargo.SalesSlno,Cargo.MAWB,stockissuedetail.SIssued_Code,
       Cargo.Check_Digit,Cargo.Airway_No,cargo.Flight_Date,Cargo.Freighter_Code,freighter.Long_Desc as Freighter,
       Cargo.Origin_Code,origin.Long_Desc as Origin, Cargo.Dest_Code,destination.Long_Desc as Destination,
       Cargo.Continent_Code,continent.Long_Desc as Continent,Cargo.Payment_Mode,payment.Long_Desc as Payment,
       Cargo.CFPaymode_Code,cargofreightpaymode.Long_Desc as CargoFreightPaymode,Cargo.Route_Code,route.Long_Desc as route,
       Cargo.Customer_Code,customer.Customer_Name as Customer,Cargo.Cargo_Code,cargotype.Long_Desc as Cargo_Type,
       Cargo.UType_Code,upliment.Long_Desc as Upliment,Cargo.HDS,Cargo.AMS,Cargo.Gross_Weight,Cargo.Chargeable_Weight,Cargo.Rate_Charge,Cargo.B_Rate
       ,Cargo.AIT,Cargo.Agent_Commission,Cargo.HBL_Qty,Cargo.Others_Charges,Cargo.THC,Cargo.SSC,Cargo.FSC_Charge,Cargo.ISS_Charge,Cargo.IsSSCVAT,Cargo.SSC_VAT,Cargo.Total_USD,cargo.Total_USD_With_SSC_Vat,cargo.Currency_Code,cargo.Exchange_Rate,cargo.Receivable_Amount_BDT,cargo.Receivable_Amount_USD_With_SSC_VAT,
	   Cargo.Consignee_Code,consignee.Consignee_Name,consignee.Consignee_Address,Cargo.Consignor_Code,consignor.Consignor_Name,consignor.Consignor_Address,Cargo.Remarks,Cargo.Exchange_Rate,Cargo.Receivable_Amount_BDT,Cargo.Remarks_B_Bank
       ,Cargo.Currency_Code,cargo.Entry_Date,Cargo.Entry_By from CargoSalesInformations Cargo

	  inner join StockIssueDetailInformations stockissuedetail on stockissuedetail.Ticket_No=cargo.mawb
	  inner join FreighterInformations freighter on cargo.Freighter_Code=freighter.Freighter_Code
	  inner join OriginInformations origin on cargo.Origin_Code=origin.Origin_Code
	  inner join DestinationInformations destination on cargo.Dest_Code=destination.Dest_Code
	  inner join ContinentInformations continent on cargo.Continent_Code=continent.Continent_Code
	  inner join PaymentModeInformations payment on cargo.Payment_Mode=payment.Payment_Mode

	  inner join CargoFreightPaymodeInformations cargofreightpaymode on cargo.CFPaymode_Code=cargofreightpaymode.CFPaymode_Code
	  inner join RouteInformations route on cargo.Route_Code=route.Route_Code
	  inner join CustomerInformations customer on cargo.Customer_Code=customer.Customer_Code
	  inner join CargoTypeInformations cargotype on cargo.Cargo_Code=cargotype.Cargo_Code
	  inner join UplimentTypeInformations upliment on cargo.UType_Code=upliment.UType_Code

	  inner join ConsigneeInformations consignee on cargo.Consignee_Code=consignee.Consignee_Code
	  inner join ConsignorInformations consignor on cargo.Consignor_Code=consignor.Consignor_Code
	   WHERE
	  cargo.Entry_Date BETWEEN @From_Date AND @To_Date
	  or Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date

	  or
	  cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	  and cargotype.Long_Desc between @From_Item and @To_Item 
	  or Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	  and cargotype.Long_Desc between @From_Item and @To_Item
	   or cargotype.Long_Desc like @CargoType

	  or cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	  and freighter.Long_Desc between @From_Item and @To_Item 
	  or Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	  and freighter.Long_Desc between @From_Item and @To_Item
	  or freighter.Long_Desc like @FreighterType


	  or cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	  and cargotype.Long_Desc between @From_Item and @To_Item 
	  or Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	  and cargotype.Long_Desc between @From_Item and @To_Item
	  or cargotype.Long_Desc like @CargoType

	  or customer.Customer_Name =@CustomerName
	  or Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	  and customer.Customer_Name=@CustomerName
	  or customer.Customer_Name like @CustomerName





END

--end

-- Last Updated Store Procedure 2/26/2020

--

USE [GSAMISDB]
GO
/****** Object:  StoredProcedure [dbo].[vwCargoSalesDetails]    Script Date: 2/26/2020 4:01:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[vwCargoSalesDetails]
	-- Add the parameters for the stored procedure here
             @From_Date datetime,
             @To_Date datetime,
	         @Flight_From_Date datetime,
	         @Flight_To_Date datetime,
			 @CustomerName varchar(90)='%',
			 @CargoType varchar(90)='%',
			 @From_Item varchar(90)='%',
			 @To_Item varchar(90)='%',
			 @CustomerGroup varchar='%',
			 @Group_From_Item varchar(90)='%',
			 @Group_To_Item varchar(90)='%'
				 
	
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Cargo.CargoSalesId,cargo.SalesSlno,Cargo.MAWB,stockissuedetail.SIssued_Code,
       Cargo.Check_Digit,Cargo.Airway_No,cargo.Flight_Date,Cargo.Freighter_Code,freighter.Long_Desc as Freighter,
       Cargo.Origin_Code,origin.Long_Desc as Origin, Cargo.Dest_Code,destination.Long_Desc as Destination,
       Cargo.Continent_Code,continent.Long_Desc as Continent,Cargo.Payment_Mode,payment.Long_Desc as Payment,
       Cargo.CFPaymode_Code,cargofreightpaymode.Long_Desc as CargoFreightPaymode,Cargo.Route_Code,route.Long_Desc as route,
       Cargo.Customer_Code,customer.Customer_Name as Customer,customer.Group_Code,Cargo.Cargo_Code,cargotype.Long_Desc as Cargo_Type,
       Cargo.UType_Code,upliment.Long_Desc as Upliment,Cargo.HDS,Cargo.AMS,Cargo.Gross_Weight,Cargo.Chargeable_Weight,Cargo.Rate_Charge,Cargo.B_Rate
       ,Cargo.AIT,Cargo.Agent_Commission,Cargo.HBL_Qty,Cargo.Others_Charges,Cargo.THC,Cargo.SSC,Cargo.FSC_Charge,Cargo.ISS_Charge,Cargo.IsSSCVAT,Cargo.SSC_VAT,Cargo.Total_USD,cargo.Total_USD_With_SSC_Vat,cargo.Currency_Code,cargo.Exchange_Rate,cargo.Receivable_Amount_BDT,cargo.Receivable_Amount_USD_With_SSC_VAT,
	   Cargo.Consignee_Code,consignee.Consignee_Name,consignee.Consignee_Address,Cargo.Consignor_Code,consignor.Consignor_Name,consignor.Consignor_Address,Cargo.Remarks,Cargo.Exchange_Rate,Cargo.Receivable_Amount_BDT,Cargo.Remarks_B_Bank
       ,Cargo.Currency_Code,cargo.Entry_Date,Cargo.Entry_By from CargoSalesInformations Cargo

	  inner join StockIssueDetailInformations stockissuedetail on stockissuedetail.Ticket_No=cargo.mawb
	  inner join FreighterInformations freighter on cargo.Freighter_Code=freighter.Freighter_Code
	  inner join OriginInformations origin on cargo.Origin_Code=origin.Origin_Code
	  inner join DestinationInformations destination on cargo.Dest_Code=destination.Dest_Code
	  inner join ContinentInformations continent on cargo.Continent_Code=continent.Continent_Code
	  inner join PaymentModeInformations payment on cargo.Payment_Mode=payment.Payment_Mode

	  inner join CargoFreightPaymodeInformations cargofreightpaymode on cargo.CFPaymode_Code=cargofreightpaymode.CFPaymode_Code
	  inner join RouteInformations route on cargo.Route_Code=route.Route_Code
	  inner join CustomerInformations customer on cargo.Customer_Code=customer.Customer_Code
	  inner join CargoTypeInformations cargotype on cargo.Cargo_Code=cargotype.Cargo_Code
	  inner join UplimentTypeInformations upliment on cargo.UType_Code=upliment.UType_Code

	  inner join ConsigneeInformations consignee on cargo.Consignee_Code=consignee.Consignee_Code
	  inner join ConsignorInformations consignor on cargo.Consignor_Code=consignor.Consignor_Code
	   WHERE
	
	  cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	   and ((cargotype.Long_Desc like @From_Item OR cargotype.Long_Desc like @To_Item) OR (cargotype.Long_Desc BETWEEN  @From_Item AND  @To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )

	  -- or cargo.Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	  --and (cargotype.Long_Desc like @From_Item and cargotype.Long_Desc like @To_Item)
	  -- and (customer.Group_Code  like @Group_From_Item OR 
	  -- customer.Group_Code like @Group_To_Item )



	 
		
	
		 
	 
	
	   






END


--end




--cargotype and freighter write store procedure
USE [GSAMISDB]
GO
/****** Object:  StoredProcedure [dbo].[vwCargoSalesDetails]    Script Date: 2/28/2020 12:43:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[vwCargoSalesDetails]
	-- Add the parameters for the stored procedure here
             @From_Date datetime,
             @To_Date datetime,
	         @Flight_From_Date datetime,
	         @Flight_To_Date datetime,
			 @CustomerName varchar(90)='%',
			 @CargoType varchar(90)='%',
			 @CargoType_From_Item varchar(90)='%',
			 @CargoType_To_Item varchar(90)='%',
			 --@FreighterType varchar(90)='%',
			 @FreighterType_From_Item varchar(90)='%',
			 @FreighterType_To_Item varchar(90)='%',
			 @CustomerGroup varchar='%',
			 @Group_From_Item varchar(90)='%',
			 @Group_To_Item varchar(90)='%'
				 
	
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Cargo.CargoSalesId,cargo.SalesSlno,Cargo.MAWB,stockissuedetail.SIssued_Code,
       Cargo.Check_Digit,Cargo.Airway_No,cargo.Flight_Date,Cargo.Freighter_Code,freighter.Long_Desc as Freighter,
       Cargo.Origin_Code,origin.Long_Desc as Origin, Cargo.Dest_Code,destination.Long_Desc as Destination,
       Cargo.Continent_Code,continent.Long_Desc as Continent,Cargo.Payment_Mode,payment.Long_Desc as Payment,
       Cargo.CFPaymode_Code,cargofreightpaymode.Long_Desc as CargoFreightPaymode,Cargo.Route_Code,route.Long_Desc as route,
       Cargo.Customer_Code,customer.Customer_Name as Customer,customer.Group_Code,Cargo.Cargo_Code,cargotype.Long_Desc as Cargo_Type,
       Cargo.UType_Code,upliment.Long_Desc as Upliment,Cargo.HDS,Cargo.AMS,Cargo.Gross_Weight,Cargo.Chargeable_Weight,Cargo.Rate_Charge,Cargo.B_Rate
       ,Cargo.AIT,Cargo.Agent_Commission,Cargo.HBL_Qty,Cargo.Others_Charges,Cargo.THC,Cargo.SSC,Cargo.FSC_Charge,Cargo.ISS_Charge,Cargo.IsSSCVAT,Cargo.SSC_VAT,Cargo.Total_USD,cargo.Total_USD_With_SSC_Vat,cargo.Currency_Code,cargo.Exchange_Rate,cargo.Receivable_Amount_BDT,cargo.Receivable_Amount_USD_With_SSC_VAT,
	   Cargo.Consignee_Code,consignee.Consignee_Name,consignee.Consignee_Address,Cargo.Consignor_Code,consignor.Consignor_Name,consignor.Consignor_Address,Cargo.Remarks,Cargo.Exchange_Rate,Cargo.Receivable_Amount_BDT,Cargo.Remarks_B_Bank
       ,Cargo.Currency_Code,cargo.Entry_Date,Cargo.Entry_By from CargoSalesInformations Cargo

	  inner join StockIssueDetailInformations stockissuedetail on stockissuedetail.Ticket_No=cargo.mawb
	  inner join FreighterInformations freighter on cargo.Freighter_Code=freighter.Freighter_Code
	  inner join OriginInformations origin on cargo.Origin_Code=origin.Origin_Code
	  inner join DestinationInformations destination on cargo.Dest_Code=destination.Dest_Code
	  inner join ContinentInformations continent on cargo.Continent_Code=continent.Continent_Code
	  inner join PaymentModeInformations payment on cargo.Payment_Mode=payment.Payment_Mode

	  inner join CargoFreightPaymodeInformations cargofreightpaymode on cargo.CFPaymode_Code=cargofreightpaymode.CFPaymode_Code
	  inner join RouteInformations route on cargo.Route_Code=route.Route_Code
	  inner join CustomerInformations customer on cargo.Customer_Code=customer.Customer_Code
	  inner join CargoTypeInformations cargotype on cargo.Cargo_Code=cargotype.Cargo_Code
	  inner join UplimentTypeInformations upliment on cargo.UType_Code=upliment.UType_Code

	  inner join ConsigneeInformations consignee on cargo.Consignee_Code=consignee.Consignee_Code
	  inner join ConsignorInformations consignor on cargo.Consignor_Code=consignor.Consignor_Code
	   
	   	   	      WHERE
	   --cargo.Entry_Date BETWEEN '2020-02-25' AND '2020-02-29'  
	   --and cargotype.Long_Desc between 'Garments' and 'Garments'

	--cargo type Entry date 
	  cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )	   
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))

	   --cargo type flight date
	   or  cargo.Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )	   
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))

	  -- freighter type OK individual run
	  
	  OR  cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	   and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )
	      and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))

	  --Freighter Type Flight date wise
	  
	    OR  cargo.Flight_Date BETWEEN  @Flight_From_Date AND @Flight_To_Date 
	   and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
 

	  



	 
		
	
		 
	   
	
	   






END


--


