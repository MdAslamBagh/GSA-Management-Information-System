using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CommonSetupInformation
    {
        [Key]
        public int CommonId { get; set; }
        public int SerialNo { get; set; }
        public string Particulars { get; set; }
        public string Description { get; set; }
        public double Particular_Value { get; set; }
        public double Minimum_Value { get; set; }
        public DateTime Entry_Date { get; set; }
    }
}