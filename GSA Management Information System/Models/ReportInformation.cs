using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class ReportInformation
    {
        [Key]
        public int ReportId { get; set; }
        public int SubMenuId { get; set; }
        public string ReportName { get; set; }
        //public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
        public DateTime Entry_Date { get; set; }
    }
}