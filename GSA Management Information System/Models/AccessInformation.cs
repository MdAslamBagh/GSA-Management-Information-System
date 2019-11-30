using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class AccessInformation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string SubMenuList { get; set; }
        public string RoleId { get; set; }

        public byte RoleStatus { get; set; }



    }
}