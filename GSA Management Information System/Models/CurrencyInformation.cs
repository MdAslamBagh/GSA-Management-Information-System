﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CurrencyInformation
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Currency_Code must be Needed.")]
        public string Currency_Code { get; set; }
        
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Long_Desc { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Short_Desc{ get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public string Status { get; set; }
        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }

    }
}