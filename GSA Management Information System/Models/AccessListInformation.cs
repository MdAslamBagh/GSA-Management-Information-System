using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class AccessListInformation
    {
        [Key]

        public int AccessId { get; set; }
        public string BaseModule { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

    }
}