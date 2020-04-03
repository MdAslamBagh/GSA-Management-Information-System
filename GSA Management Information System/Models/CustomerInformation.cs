using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CustomerInformation
    {
        [Key]
        public int CustomerId { get; set; }
        public String Customer_Code { get; set; }
        public int Bp_Code { get; set; }
        public string Customer_Name { get; set; }
        public string Sage_Code { get; set; }
        public string Type_Code { get; set; }
        public string Group_Code { get; set; }
        public string Address { get; set; }
        public int Country_Code { get; set; }
        public string City_Code { get; set; }
        public string Status { get; set; }
       public string Contact_No { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Contact_Person { get; set; }

        public bool Default_Code { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }


    }
}