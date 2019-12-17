using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class ExchangeInformation
    {
        [Key]
        public int ExchangeId { get; set; }
        [Required(ErrorMessage = "_Code must be Required.")]
        [DisplayName("Exchange_Code")]
        public string Currency_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Long_Desc { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]       
        public float Exchange_Rate { get; set; }
        public string Status { get; set; }
        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }

    }
}