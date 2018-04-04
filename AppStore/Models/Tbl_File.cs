//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Optimization;

namespace AppStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_File
    {
        public int FID { get; set; }
        public int PID { get; set; }
        [Required]
        [Display(Name = "Project File")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".zip" ,ErrorMessage = "Error... only zip file")]
        public string Ffile1 { get; set; }
        [Required]
        [Display(Name = "Document File")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".pdf", ErrorMessage = "Error... only pdf file")]
        public string Ffile2 { get; set; }
        
        [Display(Name = "Photo-1")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".jpg, .PNG", ErrorMessage = "Error... only jpg or png file")]
        public string Photo1 { get; set; }
        
        [Display(Name = "Photo-2")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".jpg, .PNG", ErrorMessage = "Error... only jpg or png file")]
        public string Photo2 { get; set; }
        [Display(Name = "Video URL")]
        [DataType(DataType.Url)]
        [MaxLength(48,ErrorMessage = "URL length not more then 45 charactr")]
        public string Url { get; set; }
    
        public virtual Tbl_Project Tbl_Project { get; set; }
    }
}
