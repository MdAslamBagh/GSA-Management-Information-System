using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class SubMenuInformation
    {
        [Key]
        public int SubMenuId { get; set; }
        public string Access_Name { get; set; }
        public int MenuItemId { get; set; }
        public string Controller_Name { get; set; }
        public string Action_Name { get; set; }
        public byte IsVisible { get; set; }
        public string Entry_By { get; set; }



    }
}