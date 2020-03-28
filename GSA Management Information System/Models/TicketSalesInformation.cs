using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class TicketSalesInformation
    {
        [Key]
        public int TicketSalesId { get; set; }
        public int Sales_Slno { get; set; }
        public int Airlines_Code { get; set; }
        public string Payment_Mode { get; set; }
        public DateTime Ticket_Date { get; set; }
        public int Ticket_No { get; set; }
        public string Customer_Code { get; set; }
        public int Bank_Code { get; set; }
        public float Exchange_Rate { get; set; }
        public int Sales_Value_USD { get; set; }
        public float Sales_Value_BDT { get; set; }
        public int Commison { get; set; }
        public float Commison_Amount { get; set; }
        public int Emb_Tax { get; set; }
        public int Travel_Tax { get; set; }
        public int Fuel_Charge { get; set; }
        public int Hk_Tax { get; set; }
        public int Xt_Charge { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public int Other_Charge { get; set; }
        public int Discount { get; set; }
        public float Net_Receivable_Amount { get; set; }
        public int Received_Amount { get; set; }
        public float Amount_In_PPRS { get; set; }
        public string Remarks { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }
        public bool IsExported { get; set; }




    }

    public class TicketSalesViewModel
    {
        [Key]
        public int TicketSalesId { get; set; }
        public string Airlines_Name { get; set; }
        public string Bank_Name { get; set; }
        public string Customer_Name { get; set; }
        public string Payment_Name { get; set; }
        public int Sales_Slno { get; set; }
        public int Airlines_Code { get; set; }
        public string Payment_Mode { get; set; }
        public DateTime Ticket_Date { get; set; }
        public int Ticket_No { get; set; }
        public string Customer_Code { get; set; }
        public int Bank_Code { get; set; }
        public float Exchange_Rate { get; set; }
        public int Sales_Value_USD { get; set; }
        public float Sales_Value_BDT { get; set; }
        public int Commison { get; set; }
        public float Commison_Amount { get; set; }
        public int Emb_Tax { get; set; }
        public int Travel_Tax { get; set; }
        public int Fuel_Charge { get; set; }
        public int Hk_Tax { get; set; }
        public int Xt_Charge { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public int Other_Charge { get; set; }
        public int Discount { get; set; }
        public float Net_Receivable_Amount { get; set; }
        public int Received_Amount { get; set; }
        public float Amount_In_PPRS { get; set; }
        public string Remarks { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }
        public bool IsExported { get; set; }





    }
}