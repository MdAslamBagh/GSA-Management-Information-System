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


        //To view employee details with generic list 
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

            //Bind EmpModel generic list using LINQ 
            CargoList = (from DataRow dr in dt.Rows

                         select new CargoViewModel()
                         {
                             CargoSalesId = Convert.ToInt32(dr["CargoSalesId"]),
                             SalesSlno = Convert.ToInt32(dr["SalesSlno"]),
                             MAWB = Convert.ToString(dr["MAWB"]),
                             SIssued_Code = Convert.ToString(dr["SIssued_Code"]),
                             Check_Digit = Convert.ToString(dr["Check_Digit"]),
                             Airway_No = Convert.ToString(dr["Airway_No"]),
                             //Flight_Date=Convert.ToString(dr["Flight_Date"]),
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

                             HDS = Convert.ToString(dr["HDS"]),
                             AMS = Convert.ToString(dr["AMS"]),
                             Gross_Weight = Convert.ToString(dr["Gross_Weight"]),
                             Chargeable_Weight = Convert.ToString(dr["Chargeable_Weight"]),
                             Rate_Charge = Convert.ToString(dr["Rate_Charge"]),
                             B_Rate = Convert.ToString(dr["B_Rate"]),
                             AIT = Convert.ToString(dr["AIT"]),
                             Agent_Commission = Convert.ToString(dr["Agent_Commission"]),
                             HBL_Qty = Convert.ToString(dr["HBL_Qty"]),
                             Others = Convert.ToString(dr["Others"]),
                             THC = Convert.ToString(dr["THC"]),
                             SSC = Convert.ToString(dr["SSC"]),
                             FSC_Charge = Convert.ToString(dr["FSC_Charge"]),
                             ISS_Charge = Convert.ToString(dr["ISS_Charge"]),
                             SSC_VAT = Convert.ToString(dr["SSC_VAT"]),
                             Total_USD = Convert.ToString(dr["Total_USD"])
                         }).ToList();


            return CargoList;


        }



        public List<CargoSalesTransactionBackup> GetCargoBackup(CargoSalesInformation cargoSalesInformation)
        {

            //CargoSalesInformation cargoSalesInformation = new CargoSalesInformation();

             List<CargoSalesTransactionBackup> CargoBackupList = new List<CargoSalesTransactionBackup>();
            CargoSalesTransactionBackup transaction = new CargoSalesTransactionBackup();
            transaction.CargoSalesId = cargoSalesInformation.CargoSalesId;
            transaction.SalesSlno = cargoSalesInformation.SalesSlno;
          
            transaction.MAWB = cargoSalesInformation.MAWB;
            transaction.Check_Digit = cargoSalesInformation.Check_Digit;
           

         
            //return (transaction)

             CargoBackupList.Add(transaction);
    

            return CargoBackupList;



        }


    }
    
}