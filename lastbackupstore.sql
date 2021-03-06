USE [GSAMISDB]
GO
/****** Object:  StoredProcedure [dbo].[vwCargoSalesDetails]    Script Date: 3/2/2020 8:47:27 AM ******/
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
			 @Group_To_Item varchar(90)='%',
			 @Destination_From_Item varchar(90)='%',
			 @Destination_To_Item varchar(90)='%',
			 @Destination varchar(90)='%',
			 @Region varchar(90)='%',
			 @Country varchar(90)='%'
			 

				 
	
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
	   country.Country_Code, country.Long_Desc AS Country, 
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
	  inner join CountryInformations country ON destination.Country_Code = country.Country_Code
	   
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
	   and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName)) 
	     and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
		and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	   --cargo type flight date
	   or  cargo.Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date 
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )	   
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName)) 
	     and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
			and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	  -- freighter type entry date
	  
	  OR  cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	   and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )
	      and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
		  and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName)) 
		    and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
				and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	  --Freighter Type Flight date
	  
	    OR  cargo.Flight_Date BETWEEN  @Flight_From_Date AND @Flight_To_Date 
	   and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName)) 
	     and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
	and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	  --Customer/Agentwise  Entry date
	  	or  cargo.Entry_Date BETWEEN @From_Date AND @To_Date
		and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName)) 
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item))	   
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	     and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
			and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	   --Customer/Agentwise Flight Date
	   or  cargo.Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date
		and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName)) 
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item))	   
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	     and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
			and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	   --Destination wise Entry Date

	   or  cargo.Entry_Date BETWEEN @From_Date AND @To_Date 
	   and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )	 
	     and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))  
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName))
	  	and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	   --destination wise Flight Date

	    or  cargo.Flight_Date BETWEEN @Flight_From_Date AND @Flight_To_Date
	   and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item)  )	 
	     and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))  
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	   and ((customer.Customer_Name like @CustomerName) OR (customer.Customer_Name=@CustomerName))
	  	and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	   --Continent Wise Entry Date 
	
	   or  cargo.Entry_Date BETWEEN @From_Date AND @To_Date
		and ((origin.Long_Desc like @Region) OR (origin.Long_Desc=@Region) and (country.Long_Desc like @Country) or (country.Long_Desc=@Country) )
	   and ((cargotype.Long_Desc like @CargoType_From_Item OR cargotype.Long_Desc like @CargoType_To_Item) OR (cargotype.Long_Desc BETWEEN  @CargoType_From_Item AND  @CargoType_To_Item))
	   and ((customer.Group_Code  like @Group_From_Item OR 
	   customer.Group_Code like @Group_To_Item)OR(customer.Group_Code  Between @Group_From_Item and  @Group_To_Item))	   
       and ((freighter.Long_Desc like @FreighterType_From_Item OR freighter.Long_Desc like @FreighterType_To_Item) 
	   OR (freighter.Long_Desc BETWEEN  @FreighterType_From_Item AND  @FreighterType_To_Item))
	     and ((destination.Long_Desc like @Destination_From_Item OR destination.Long_Desc like @Destination_To_Item) OR (destination.Long_Desc BETWEEN  @Destination_From_Item AND  @Destination_To_Item))

	 
		
	
		 
	 
	
	   






END

