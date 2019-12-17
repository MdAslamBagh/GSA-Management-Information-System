using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CargoTypeInformation
    {
        [Key]
        public int CargoTypeId { get; set; }

        [Required(ErrorMessage = "Type_Code must be Needed.")]
        public string Cargo_Code { get; set; }
        [DisplayName("Cargo_Type")]
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Long_Desc { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Status { get; set; }

        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}