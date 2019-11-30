using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CustomerTypeInformation
    {
        [Key]
        public int CustomerTypeId { get; set; }

        [Required(ErrorMessage = "Type_Code must be Needed.")]
        public string Type_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        [DisplayName("Customer_Type")]
        public string Long_Desc { get; set; }

        [Required(ErrorMessage = "Please Select the status.")]
        public string Status { get; set; }
        
        public bool Default_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
    }
}