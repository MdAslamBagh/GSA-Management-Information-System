using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CustomerGroupInformation
    {
      [Key]
        public int CustomerGroupId { get; set; }
        [Required(ErrorMessage = "Group_Code must be Needed.")]
        public string Group_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        [DisplayName("Customer_Group")]
        public string Long_Desc { get; set; }

        [Required(ErrorMessage = "Please Select the Status.")]
        public string Status { get; set; }
        
        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}