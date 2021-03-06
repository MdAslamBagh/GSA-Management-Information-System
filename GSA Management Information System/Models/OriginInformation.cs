﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class OriginInformation
    {
        [Key]
        public int OriginId { get; set; }
       
        [Required(ErrorMessage = "Origin_Code must be Needed.")]
        public string Origin_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        [DisplayName("Description")]
        public string Long_Desc { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public string Status { get; set; }
        public bool Default_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}