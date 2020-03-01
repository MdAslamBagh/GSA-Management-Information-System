using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class BangladeshBankReport
    {
        [Key]
        public int BangladeshBankReportId { get; set; }
        public int SubMenuId { get; set; }
        public string MAWB { get; set; }
        public string Airway_No { get; set; }
        public DateTime Entry_Date { get; set; }
        public DateTime Flight_Date { get; set; }

    }
}