using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CourierOutboundSalesInformation
    {
        [Key]
        public string SalesSlno { get; set; }
        public string MAWB { get; set; }
        public string Check_Digit { get; set; }
        public DateTime Flight_Date { get; set; }
        public int Airlines_Code { get; set; }
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
        public int HDS { get; set; }
        public int AMS { get; set; }
        public int Gross_Weight { get; set; }
        public int Chargeable_Weight { get; set; }
        public int Rate_Charge { get; set; }
        public int B_Rate { get; set; }
        public int AIT { get; set; }
        public int Agent_Commission { get; set; }
        public int HBL_Qty { get; set; }
        public int Others { get; set; }
        public int THC { get; set; }
        public int SSC { get; set; }
        public int FSC_Charge { get; set; }
        public int ISS_Charge { get; set; }
        public int SSC_VAT { get; set; }
        public int Total_USD { get; set; }
        public int Total_SSC { get; set; }
        public string Consignee_Code { get; set; }
        public string Consignor_Code { get; set; }
        public int Receivable_From_Agent { get; set; }
        public string Remarks { get; set; }
        public string Currency { get; set; }
        public int Exchange_Rate { get; set; }
        //public int Tact_Rate { get; set; }
        //public int Adhoc_Rate { get; set; }
        //public int Spa_Rate { get; set; }
        
        public int Receivable_Amount_BDT { get; set; }
        public int Payable_Agent_CC { get; set; }

        public string Remarks_B_Bank { get; set; }

        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }

    }
}