using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class MenuItemInformation
    {
        [Key]
        public int MenuItemId { get; set; }
        public string Menu_Name { get; set; }
        public string ModuleIcon { get; set; }
        public string Entry_By { get; set; }

        //  public List<AccessInformation> AccessList { get; set; }



    }
    //public class Menu
    //{
    //    public string UserName { get; set; }
    //    public string GroupName { get; set; }
    //    public List<MenuItemInformation> MenuList { get; set; }
    //}

}