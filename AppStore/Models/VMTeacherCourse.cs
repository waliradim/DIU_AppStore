using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class VMTeacherCourse
    {
        public string SemesterName { get; set; }
        public int TID { get; set; }
        public int CID { get; set; }
        public int SID { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public DateTime date { get; set; }

    }
}