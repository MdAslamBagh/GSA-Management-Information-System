using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CargoDueReceipt
    {
        public int CargoDueReceiptId { get; set; }
        public int SalesSlno { get; set; }
        public string Airway_No { get; set; }
        public string Customer_Code { get; set; }
        public string Document_Type { get; set; }

        public string Receipt_No { get; set; }

        public DateTime Receipt_Date { get; set; }
        public float Receipt_Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }







    }
}