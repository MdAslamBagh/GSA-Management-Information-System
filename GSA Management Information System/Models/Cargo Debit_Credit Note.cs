using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class Cargo_Debit_Credit_Note
    {
        public int Id { get; set; }
        public DateTime Trans_Date { get; set; }
        public string Type { get; set; }
        public string Customer_Name { get; set; }
        public string Reference_No { get; set; }
        public int Currency { get; set; }
        public float Exchange_Rate { get; set; }
        public float Amount_USD { get; set; }
        public float Amount_BDT { get; set; }
        public string Remarks { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }


    }
}