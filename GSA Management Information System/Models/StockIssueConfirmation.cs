using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class StockIssueConfirmation
    {
        [Key]
        public int CIssueId { get; set; }
       
        public string SIssued_Code { get; set; }
        
        //public DateTime Issue_Date { get; set; }
       

        public int Airlines_Code { get; set; }
      
        public int From_TicketNo { get; set; }

  
        public int To_TicketNo { get; set; }

        public int Ticket_Quantity { get; set; }
 
        public string Customer_Code { get; set; }
    
        public string Remarks { get; set; }

        public string Status { get; set; }
        public DateTime Confirm_Date { get; set; }
        public string Entry_By { get; set; }

    }
}