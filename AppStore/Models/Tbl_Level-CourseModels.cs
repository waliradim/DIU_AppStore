using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStore.Models
{
    public class Tbl_Level_CourseModels
    {
        public int LID { get; set; }
        public int CID { get; set; }

        public virtual Tbl_Course Tbl_Course { get; set; }
        public virtual Tbl_Level Tbl_Level { get; set; }

    }
}