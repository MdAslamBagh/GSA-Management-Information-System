using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class RouteInformation
    {
        [Key]
        public int RouteId { get; set; }
        [Required(ErrorMessage = "Upliment_Code must be Required.")]
        public string Route_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Long_Desc { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        [DisplayName("Type")]
        public string Type_Code{ get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Status { get; set; }
        public bool Default_Code { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}