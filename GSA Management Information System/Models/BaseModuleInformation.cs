using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class BaseModuleInformation
    {
        [Key]
        public int BaseModuleId { get; set; }
        public string BaseModule { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}