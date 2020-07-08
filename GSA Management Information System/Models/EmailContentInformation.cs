using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class EmailContentInformation
    {
        [Key]
        public int EmailId { get; set; }

        //[Required(ErrorMessage = "Email is required.")]
        ////[RegularExpression(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4},?)+$", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        //[RegularExpression(@"^(\s?[^\s,]+@[^\s,]+\.[^\s,]+\s?,)*(\s?[^\s,]+@[^\s,]+\.[^\s,]+)$", ErrorMessage = "Please enter valid Email:example@gmail.com")]
        //public string Email { get; set; }
        public string From { get; set; }
        public string To { get; set; }   
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string HostServer { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string SmtpPort { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }

    }
}