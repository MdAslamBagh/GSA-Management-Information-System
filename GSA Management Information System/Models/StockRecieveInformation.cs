using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSA_Management_Information_System.Models
{
    public class StockRecieveInformation
    {
        [Key]
        public int SRecievedId { get; set; }
        [Required(ErrorMessage = "SRecieved_Code must be Required.")]
        public string SRecieved_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public  string SR_Type { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Trans_Date { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public int Airlines_Code { get; set; }
        [Required]
        
        [RegularExpression("[0-9]{7,7}", ErrorMessage = "Ticket No must be 7 digit")]
        [Remote("FromTicketAlreadyExists", "StockRecieveInformation", ErrorMessage = "Starting Ticket Already Exist")]

        public int From_TicketNo { get; set; }
        [Required]
        [RegularExpression("[0-9]{7,7}", ErrorMessage = "Ticket No must be 7 digit")]

        public int To_TicketNo { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public int Ticket_Quantity { get; set; }

        public string Customer_Code { get; set; }
        public virtual CustomerInformation CustomerInformation { get; set; }
        public string Remarks { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Transaction_Status { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Issued { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get;set; }
        public string Entry_By { get; set; }
    }
}