using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public class UserInformation
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
        public string Company_Code { get; set; }
        public string Branch_Code { get; set; }
        public string Password { get; set; }
        public string Confirm_Password {get;set;}

    }
}