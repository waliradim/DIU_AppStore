using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;
using Microsoft.Owin;

namespace AppStore.Controllers
{
    public class HomeController : Controller
    {
        public DIU_App_StoreEntities db=new DIU_App_StoreEntities();
        public  ProjectController Ps=new ProjectController();
        // GET: Home
        public ActionResult Index()
        {
            
           
            var project = db.Tbl_Project.Select(a => new VMHomeView()
            {
                Pid=a.PID,
                
                ProjectName =a.Pname,
                CourseName = a.Tbl_Course.CourseName,
                CourseCode = a.Tbl_Course.CourseCode,
                TeacherName = a.Tbl_Teacher.Tname,
                StudentName = a.Tbl_Student.Sname,
                SemesterName = a.Tbl_Semester.SemesterName
            }).ToList();


            return View(project);
        }

        
        //public ActionResult Details(int id)
        //{
        //    return View(RedirectToAction("Details", "Project", id));

        //}
    }
}