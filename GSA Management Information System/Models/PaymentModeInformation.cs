using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class PaymentModeInformation
    {
        [Key]
        public int PaymentModeId { get; set; }

        public int Payment_Code { get; set; }

        public string Payment_Mode { get; set; }

      
        public string Long_Desc { get; set; }
        public string Status { get; set; }

        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}