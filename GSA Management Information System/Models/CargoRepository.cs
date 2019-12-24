using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace GSA_Management_Information_System.Models
{
    public class CargoRepository
    {
        public SqlConnection con;
        //To Handle connection related activities
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
            con = new SqlConnection(constr);

        }


        //To view Cargo Sales details with generic list
        public List<CargoViewModel> GetAllCargo()
        {
            connection();
            List<CargoViewModel> CargoList = new List<CargoViewModel>();
            SqlCommand com = new SqlCommand("spCargoSalesDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            //Bind CargoSalesModel generic list using LINQ 
            CargoList = (from DataRow dr in dt.Rows

                         select new CargoViewModel()
                         {
                             CargoSalesId = Convert.ToInt32(dr["CargoSalesId"]),
                             SalesSlno = Convert.ToInt32(dr["SalesSlno"]),
                             MAWB = Convert.ToString(dr["MAWB"]),
                             SIssued_Code = Convert.ToString(dr["SIssued_Code"]),
                             Check_Digit = Convert.ToString(dr["Check_Digit"]),
                             Airway_No = Convert.ToString(dr["Airway_No"]),

                             Flight_Date = (DateTime)dr["Flight_Date"],
                             //Convert.ToDateTime(dr["Flight_Date"].ToString()),
                             Freighter_Code = Convert.ToInt32(dr["Freighter_Code"]),
                             Freighter = Convert.ToString(dr["Freighter"]),
                             Origin_Code = Convert.ToString(dr["Origin_Code"]),
                             Origin = Convert.ToString(dr["Origin"]),
                             Dest_Code = Convert.ToString(dr["Dest_Code"]),
                             Destination = Convert.ToString(dr["Destination"]),
                             Continent_Code = Convert.ToInt32(dr["Continent_Code"]),
                             Continent = Convert.ToString(dr["Continent"]),
                             Payment_Mode = Convert.ToString(dr["Payment_Mode"]),
                             Payment = Convert.ToString(dr["Payment"]),
                             CFPaymode_Code = Convert.ToInt32(dr["CFPaymode_Code"]),
                             CargoFreightPaymode = Convert.ToString(dr["CargoFreightPaymode"]),
                             Route_Code = Convert.ToString(dr["Route_Code"]),
                             Route = Convert.ToString(dr["Route"]),
                             Customer_Code = Convert.ToString(dr["Customer_Code"]),
                             Customer = Convert.ToString(dr["Customer"]),
                             Cargo_Code = Convert.ToString(dr["Cargo_Code"]),
                             CargoType = Convert.ToString(dr["CargoType"]),
                             UType_Code = Convert.ToInt32(dr["UType_Code"]),
                             Upliment = Convert.ToString(dr["Upliment"]),


                             Consignee_Code = Convert.ToString(dr["Consignee_Code"]),
                             Consignee_Name = Convert.ToString(dr["Consignee_Name"]),
                             Consignee_Address = Convert.ToString(dr["Consignee_Address"]),
                             Consignor_Code = Convert.ToString(dr["Consignor_Code"]),
                             Consignor_Name = Convert.ToString(dr["Consignor_Name"]),
                             Consignor_Address = Convert.ToString(dr["Consignor_Address"]),
                             //float value

                             HDS = (float)(dr["HDS"]),
                             AMS = (float)(dr["AMS"]),
                             Gross_Weight = (float)(dr["Gross_Weight"]),
                             Chargeable_Weight = (float)(dr["Chargeable_Weight"]),
                             Rate_Charge = (float)(dr["Rate_Charge"]),
                             B_Rate = (float)(dr["B_Rate"]),
                             AIT = (float)(dr["AIT"]),
                             Agent_Commission = (float)(dr["Agent_Commission"]),
                             HBL_Qty = (float)(dr["HBL_Qty"]),
                             Others = (float)(dr["Others"]),
                             THC = (float)(dr["THC"]),
                             SSC = (float)(dr["SSC"]),
                             FSC_Charge = (float)(dr["FSC_Charge"]),
                             ISS_Charge = (float)(dr["ISS_Charge"]),
                             CheckSSCVat= Convert.ToBoolean(dr["CheckSSCVat"]),
                             SSC_VAT = (float)(dr["SSC_VAT"]),
                             Total_USD = (float)(dr["Total_USD"]),
                             Total_USD_With_SSC_Vat= (float)(dr["Total_USD_With_SSC_Vat"]),
                             Currency_Code = Convert.ToString(dr["Currency_Code"]),
                             Exchange_Rate = (float)(dr["Exchange_Rate"]),
                             Receivable_Amount_BDT= (float)(dr["Receivable_Amount_BDT"]),
                             Receivable_Amount_USD_With_SSC_VAT= (float)(dr["Receivable_Amount_USD_With_SSC_VAT"]),
                             Remarks = Convert.ToString(dr["Remarks"]),
                             Remarks_B_Bank = Convert.ToString(dr["Remarks_B_Bank"]),
                             Entry_Date = (DateTime)dr["Entry_Date"],



                             Entry_By = Convert.ToString(dr["Entry_By"]),



                         }).ToList();


            return CargoList;


        }


        //Cargo Sales Information Transaction Backup in Create method by passing object
        public List<CargoSalesTransactionBackup> GetCargoBackup(CargoSalesInformation cargoSalesInformation)
        {

            //CargoSalesInformation cargoSalesInformation = new CargoSalesInformation();

             List<CargoSalesTransactionBackup> CargoBackupList = new List<CargoSalesTransactionBackup>();
            CargoSalesTransactionBackup transaction = new CargoSalesTransactionBackup();
            transaction.CargoSalesId = cargoSalesInformation.CargoSalesId;
            transaction.SalesSlno = cargoSalesInformation.SalesSlno;

            //transaction.MAWB = cargoSalesInformation.MAWB;
            //transaction.Check_Digit = cargoSalesInformation.Check_Digit;



            transaction.MAWB = cargoSalesInformation.MAWB;
            transaction.Check_Digit = cargoSalesInformation.Check_Digit;
            transaction.Airway_No = cargoSalesInformation.MAWB + cargoSalesInformation.Check_Digit;
            transaction.Flight_Date = cargoSalesInformation.Flight_Date;
            transaction.Freighter_Code = cargoSalesInformation.Freighter_Code;
            transaction.Origin_Code = cargoSalesInformation.Origin_Code;
            transaction.Dest_Code = cargoSalesInformation.Dest_Code;
            transaction.Continent_Code = cargoSalesInformation.Continent_Code;
            transaction.Payment_Mode = cargoSalesInformation.Payment_Mode;
            transaction.CFPaymode_Code = cargoSalesInformation.CFPaymode_Code;
            transaction.Route_Code = cargoSalesInformation.Route_Code;
            transaction.Customer_Code = cargoSalesInformation.Customer_Code;
            transaction.Cargo_Code = cargoSalesInformation.Cargo_Code;
            transaction.UType_Code = cargoSalesInformation.UType_Code;
            transaction.Consignee_Code = cargoSalesInformation.Consignee_Code;
            transaction.Consignor_Code = cargoSalesInformation.Consignor_Code;
            transaction.HDS = cargoSalesInformation.HDS;
            transaction.Others = cargoSalesInformation.Others;
            transaction.AMS = cargoSalesInformation.AMS;
            transaction.HBL_Qty = cargoSalesInformation.HBL_Qty;
            transaction.Gross_Weight = cargoSalesInformation.Gross_Weight;
            transaction.Chargeable_Weight = cargoSalesInformation.Chargeable_Weight;
            transaction.Rate_Charge = cargoSalesInformation.Rate_Charge;
            transaction.B_Rate = cargoSalesInformation.B_Rate;
            transaction.Agent_Commission = cargoSalesInformation.Agent_Commission;
            transaction.AIT = cargoSalesInformation.AIT;
            transaction.THC = cargoSalesInformation.THC;
            transaction.SSC = cargoSalesInformation.SSC;
            transaction.CheckSSCVat = cargoSalesInformation.CheckSSCVat;
            transaction.SSC_VAT = cargoSalesInformation.SSC_VAT;
            transaction.FSC_Charge = cargoSalesInformation.FSC_Charge;
            transaction.ISS_Charge = cargoSalesInformation.ISS_Charge;
            transaction.Total_USD = cargoSalesInformation.Total_USD;
            transaction.Total_USD_With_SSC_Vat = cargoSalesInformation.Total_USD_With_SSC_Vat;
            transaction.Currency_Code = cargoSalesInformation.Currency_Code;
            transaction.Exchange_Rate = cargoSalesInformation.Exchange_Rate;
            transaction.Receivable_Amount_BDT = cargoSalesInformation.Receivable_Amount_BDT;
            transaction.Receivable_Amount_USD_With_SSC_VAT = cargoSalesInformation.Receivable_Amount_USD_With_SSC_VAT;
            transaction.Remarks = cargoSalesInformation.Remarks;
            transaction.Remarks_B_Bank = cargoSalesInformation.Remarks_B_Bank;
            transaction.Entry_Date = cargoSalesInformation.Entry_Date;

            CargoBackupList.Add(transaction);
    

            return CargoBackupList;



        }



        //Cargo Sales Information Transaction Backup in Edit method by passing Object
        public List<CargoSalesTransactionBackup> GetCargoBackupEdit(CargoViewModel cargoedit)
        {

            //CargoSalesInformation cargoSalesInformation = new CargoSalesInformation();

            List<CargoSalesTransactionBackup> CargoBackupListt = new List<CargoSalesTransactionBackup>();
            CargoSalesTransactionBackup transaction = new CargoSalesTransactionBackup();
            transaction.CargoSalesId = cargoedit.CargoSalesId;
            transaction.SalesSlno = cargoedit.SalesSlno;

            //transaction.MAWB = cargoedit.MAWB;
            //transaction.Check_Digit = cargoedit.Check_Digit;


            transaction.MAWB = cargoedit.MAWB;
            transaction.Check_Digit = cargoedit.Check_Digit;
            transaction.Airway_No = cargoedit.MAWB + cargoedit.Check_Digit;
            transaction.Flight_Date = cargoedit.Flight_Date;

            transaction.Freighter_Code = cargoedit.Freighter_Code;
            transaction.Origin_Code = cargoedit.Origin_Code;
            transaction.Dest_Code = cargoedit.Dest_Code;
            transaction.Continent_Code = cargoedit.Continent_Code;
            transaction.Payment_Mode = cargoedit.Payment_Mode;
            transaction.CFPaymode_Code = cargoedit.CFPaymode_Code;
            transaction.Route_Code = cargoedit.Route_Code;
            transaction.Customer_Code = cargoedit.Customer_Code;
            transaction.Cargo_Code = cargoedit.Cargo_Code;
            transaction.UType_Code = cargoedit.UType_Code;
            transaction.Consignee_Code = cargoedit.Consignee_Code;
            transaction.Consignor_Code = cargoedit.Consignor_Code;
            transaction.HDS = cargoedit.HDS;
            transaction.Others = cargoedit.Others;
            transaction.AMS = cargoedit.AMS;
            transaction.HBL_Qty = cargoedit.HBL_Qty;
            transaction.Gross_Weight = cargoedit.Gross_Weight;
            transaction.Chargeable_Weight = cargoedit.Chargeable_Weight;
            transaction.Rate_Charge = cargoedit.Rate_Charge;
            transaction.B_Rate = cargoedit.B_Rate;
            transaction.Agent_Commission = cargoedit.Agent_Commission;
            transaction.AIT = cargoedit.AIT;
            transaction.THC = cargoedit.THC;
            transaction.SSC = cargoedit.SSC;
            transaction.SSC_VAT = cargoedit.SSC_VAT;
            transaction.FSC_Charge = cargoedit.FSC_Charge;
            transaction.ISS_Charge = cargoedit.ISS_Charge;
            transaction.Total_USD = cargoedit.Total_USD;
            transaction.Total_USD_With_SSC_Vat = cargoedit.Total_USD_With_SSC_Vat;
            transaction.Currency_Code = cargoedit.Currency_Code;
            transaction.Exchange_Rate = cargoedit.Exchange_Rate;
            transaction.Receivable_Amount_BDT = cargoedit.Receivable_Amount_BDT;
            transaction.Receivable_Amount_USD_With_SSC_VAT = cargoedit.Receivable_Amount_USD_With_SSC_VAT;
            transaction.Remarks = cargoedit.Remarks;
            transaction.Remarks_B_Bank = cargoedit.Remarks_B_Bank;
            transaction.Entry_Date = cargoedit.Entry_Date;

            CargoBackupListt.Add(transaction);


            return CargoBackupListt;



        }
    }
    
}