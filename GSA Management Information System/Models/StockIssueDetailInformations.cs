using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class StockIssueDetailInformations
    {
        [Key]
        public int SDetailsId { get; set; }
        public string SIssued_Code { get; set; }
        public int Ticket_No { get; set; }
        public String Status { get; set; }



    }
}