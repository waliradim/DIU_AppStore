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
    
    public partial class Tbl_AssignCourse
    {
        public int id { get; set; }
        public int TID { get; set; }
        public int LID { get; set; }
        public int SemesterID { get; set; }
        public int CID { get; set; }
    
        public virtual Tbl_Course Tbl_Course { get; set; }
        public virtual Tbl_Level Tbl_Level { get; set; }
        public virtual Tbl_Semester Tbl_Semester { get; set; }
        public virtual Tbl_Teacher Tbl_Teacher { get; set; }
    }
}
