using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class ProjectViewModels
    {
        public ProjectViewModels()
        {
            ProjectReport = new List<HttpPostedFileBase>();
            ProjectFile = new List<HttpPostedFileBase>();
            ProjectScreenshot1 = new List<HttpPostedFileBase>();
            ProjectScreenshot2 = new List<HttpPostedFileBase>();

        }

        [Key]
        public int Pid { get; set; }
        public int Tid { get; set; }
        public int Stid { get; set; }
        public int Cid { get; set; }
        public int Sid { get; set; }
        [Required(ErrorMessage = "your project name")]
        [Display(Name = "Project Name")]
        [DataType(DataType.Text)]
        [StringLength(45, ErrorMessage = "Maximum 45 character minimum 3", MinimumLength = 3)]
        public string PName { get; set; }
        [Required(ErrorMessage = "write project About")]
        [Display(Name = "About Project")]
        [DataType(DataType.MultilineText)]
        [StringLength(245, ErrorMessage = "Maximum 245 character minimum 3", MinimumLength = 3)]
        public string PDetails { get; set;}
        [Required(ErrorMessage = " Project Report File")]
        [Display(Name = "Project Report")]
        [FileExtensions(Extensions = ".zip", ErrorMessage = "Error... only zip file")]
        public List<HttpPostedFileBase> ProjectReport { get; set; }
        [Required]
        [Display(Name = "Project File")]
        public List<HttpPostedFileBase> ProjectFile { get; set; }
        [Required]
        [Display(Name = "Project Photo-1")]
        public List<HttpPostedFileBase> ProjectScreenshot1 { get; set; }
        [Required]
        [Display(Name = "Project Photo-2")]
        public List<HttpPostedFileBase> ProjectScreenshot2 { get; set; }
        [Display(Name = "Project Demo URL(Youtube)")]

        public string Url { get; set; }
    }
}