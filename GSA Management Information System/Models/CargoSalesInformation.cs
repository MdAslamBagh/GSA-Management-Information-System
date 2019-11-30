﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CargoSalesInformation
    {
        [Key]
        public  int CargoSalesId { get; set; }
        public int SalesSlno { get; set; }
        public string MAWB { get; set; }
        public string Check_Digit { get; set; }
        public DateTime Flight_Date { get; set; }
        //public int Airlines_Code { get; set; }
        public string Airway_No { get; set; }
        public int Freighter_Code { get; set; }
        public string Origin_Code { get; set; }
        public string Dest_Code { get; set; }
        public int Continent_Code { get; set; }
        public string Payment_Mode { get; set; }
        public int CFPaymode_Code { get; set; }
        public string Route_Code { get; set; }
        public string Customer_Code { get; set; }
        public string Cargo_Code { get; set; }
        public int UType_Code { get; set; }
        public float HDS { get; set; }
        public float AMS { get; set; }
        public float Gross_Weight { get; set; }
        public float Chargeable_Weight { get; set; }
        public float Rate_Charge { get; set; }
        public float B_Rate { get; set; }
        public float AIT { get; set; }
        public float Agent_Commission { get; set; }
        public float HBL_Qty { get; set; }
        public float Others { get; set; }
        public float THC { get; set; }
        public float SSC { get; set; }
        public float FSC_Charge { get; set; }
        public float ISS_Charge { get; set; }
        public float SSC_VAT { get; set; }
        public float Total_USD { get; set; }
        //public float Total_SSC { get; set; }
        public string Consignee_Code { get; set; }
        public string Consignor_Code { get; set; }
       // public int Receivable_From_Agent { get; set; }
        public string Remarks { get; set; }
        public string Currency_Code { get; set; }
        public float Exchange_Rate { get; set; }
        //public int Tact_Rate { get; set; }
        //public int Adhoc_Rate { get; set; }
        //public int Spa_Rate { get; set; }
        public float Receivable_Amount_USD_With_SSC_VAT { get; set; }
        public float Receivable_Amount_BDT { get; set; }
        //public float Payable_Agent_CC { get; set; }

        public string Remarks_B_Bank { get; set; }

        public DateTime Entry_Date { get; set; }
        public bool CheckSSCVat { get; set; }

    }
}