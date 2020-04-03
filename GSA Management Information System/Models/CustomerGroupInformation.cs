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
        public string Group_Code { get; set; }


        public string Long_Desc { get; set; }

        public string Status { get; set; }
        
        public bool Default_Code { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}