using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class ContinentInformation
    {

        [Key]
        public int ContinentId { get; set; }
        [Required(ErrorMessage = "Continent_Code must be Required.")]
        public int Continent_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        [DisplayName("Continent")]
        public string Long_Desc { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public float FSC_Charge { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public float ISS_Charge { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Status { get; set; }
        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
    }
}