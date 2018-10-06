using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace AppStore.Models
{
    public class VMHomeView
    {
        public int id { get; set; }
        public int Fid { get; set; }
        public int Pid { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string ProjectName { get; set; }
        public string TeacherName { get; set; }
        public string SemesterName { get; set; }
        public string StudentName { get; set; }

    }
}