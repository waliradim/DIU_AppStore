//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_File
    {
        public int FID { get; set; }
        public int PID { get; set; }
        public string Ffile1 { get; set; }
        public string Ffile2 { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Url { get; set; }
    
        public virtual Tbl_Project Tbl_Project { get; set; }
    }
}
