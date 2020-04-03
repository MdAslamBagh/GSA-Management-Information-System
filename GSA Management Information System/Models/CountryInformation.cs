using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class CountryInformation
    {
        [Key]
        public int CountryId { get; set; }
        public int Continent_Code { get; set; }
        public int Country_Code { get; set; }
        public string Long_Desc { get; set; }
        public string Status { get; set; }
        public bool Default_Code { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Entry_By { get; set; }
    }
}