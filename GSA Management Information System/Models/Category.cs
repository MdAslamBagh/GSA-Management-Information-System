using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class Category
    {
        [Key]
        public int CatagoryId { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
    }
}