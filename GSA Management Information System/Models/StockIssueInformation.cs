using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class StockIssueInformation
    {

        [Key]
        public int SIssueId { get; set; }
        [Required(ErrorMessage = "SIssueCode must be Required")]
        public string SIssued_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string SRecieved_Code { get; set; }
        public string Stock_Type { get; set; }
        public DateTime Issue_Date { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public int Airlines_Code { get; set; }
        [Required]

        [RegularExpression("[0-9]{7,7}", ErrorMessage = "Ticket No must be 7 digit")]
        public int From_TicketNo { get; set; }

        [Required]

        [RegularExpression("[0-9]{7,7}", ErrorMessage = "Ticket No must be 7 digit")]
        public int To_TicketNo { get; set; }

        public int Ticket_Quantity { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Customer_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
      
        public string Remarks { get; set; }
        public string Transaction_Status { get; set; }
        public string Confirm_Status { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }


    }
}