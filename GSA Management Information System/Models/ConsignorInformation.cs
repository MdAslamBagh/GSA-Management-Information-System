using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class ConsignorInformation
    {
        [Key]
        public int ConsignorId { get; set; }

        [Required(ErrorMessage = "Consignor_Code must be Required.")]
        public string Consignor_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public string Consignor_Name { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public string Consignor_Address { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        //[RegularExpression("[^@,]+@[^@,]+(,[^@,]+@[^@,]+)*", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        //[RegularExpression(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4},?)+$", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        [RegularExpression(@"^(\s?[^\s,]+@[^\s,]+\.[^\s,]+\s?,)*(\s?[^\s,]+@[^\s,]+\.[^\s,]+)$", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select the status.")]
        public string Status { get; set; }
        public bool Default_Code { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}