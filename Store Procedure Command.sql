 --if master date select then Entry Date wise
 --if flight date select then Flight Date Wise

 --//EntryDate/Master Date Command
 EXEC spCargoSalesDetailsByMasterEntryDate @From_Date = '2020-01-16 17:38:35.000', @To_Date = '2020-01-18 17:38:35.000'
 
 
 --//Flight Date Wise Command
  Execute vwCargoSalesDetails @From_Date = '2020-01-15 00:00:00.000', @To_Date = '2020-01-15 00:00:00.000',@Flight_From_Date=null,@Flight_To_Date=null;

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



