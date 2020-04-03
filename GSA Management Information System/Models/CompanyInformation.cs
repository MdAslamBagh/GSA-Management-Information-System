using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GSA_Management_Information_System.Models
{
    public partial class CompanyInformation
    {
        [Key]
        public int CompanyId { get; set; }

       // [Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Name { get; set; }

       // [Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Code { get; set; }

      //  [Required(ErrorMessage = "This field can not be empty.")]
        public string Branch_Name { get; set; }

        [Required(ErrorMessage = "This field can not be empty.")]
        public string Branch_Code { get; set; }

        //[Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Tin { get; set; }
        //[Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Address { get; set; }
        //[Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Postcode { get; set; }
        //[Required(ErrorMessage = "This field can not be empty.")]
        public string Company_City { get; set; }
        //[Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Country { get; set; }
        public string Company_ContacNo { get; set; }
        public string Company_Fax { get; set; }
        [Required(ErrorMessage = "This field can not be empty.")]
        public string Company_Email { get; set; }
        public string Company_Web { get; set; }
        public string Company_Dialogue { get; set; }
        //[Required(ErrorMessage = "This field can not be empty.")]
        public DateTime Entry_Date { get; set; }
        public bool Default_Code { get; set; }
        [DisplayName("Image")]
        public string Company_ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase Company_ImageUpload { get; set; }
        public string Entry_By { get; set; }

    }
}