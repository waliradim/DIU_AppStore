using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;




namespace AppStore.Models
{
    [Table("tbl_UserInfo")]
    public class UserRegInfoModel
    {
       
        
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name ="First Name")]
        public string uFirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string uLastName { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "E-mail Name is Required")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string uEmail { get; set; }
        [Required(ErrorMessage = "Password Name is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string uPassword { get; set; }
        [Display(Name = "Photo")]
        public string uPhoto { get; set; }
        
        public string uActive { get; set; }
    }
}