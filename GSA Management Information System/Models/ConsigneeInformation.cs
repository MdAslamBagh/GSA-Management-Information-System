using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class ConsigneeInformation
    {
        [Key]
        public int ConsigneeId { get; set; }
        public string Consignee_Code { get; set; }
        public string Consignee_Name { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Consignee_Address { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        //[RegularExpression(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4},?)+$", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        [RegularExpression(@"^(\s?[^\s,]+@[^\s,]+\.[^\s,]+\s?,)*(\s?[^\s,]+@[^\s,]+\.[^\s,]+)$", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        public string Email { get; set; }
        public string Status { get; set; }        
        public bool Default_Code { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }

    }
}