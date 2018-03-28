using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    [Table("Tbl_Admin")]
    public class AdminModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [StringLength(30, ErrorMessage = "User Name", MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        [Display(Name = " Password")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password minmum 6 and maximum 30", MinimumLength = 6)]
        public string Password { get; set; }
    }
}