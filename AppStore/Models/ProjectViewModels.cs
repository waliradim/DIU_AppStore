using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class ProjectViewModels
    {
        [Key]
        public int Pid { get; set; }
        public int Tid { get; set; }
        public int Stid { get; set; }
        public int Cid { get; set; }
        public int Semid { get; set; }
        public string PName { get; set; }
        [DataType(DataType.MultilineText)]
        public string PDetails { get; set;}
        public HttpPostedFileBase Fil1 { get; set; }
        public HttpPostedFileBase Fil2 { get; set; }
        public HttpPostedFileBase Pho1 { get; set; }
        public HttpPostedFileBase Pho2 { get; set; }
        public string Url { get; set; }
    }
}