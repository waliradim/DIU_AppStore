using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;

namespace AppStore.Controllers
{
    public class StudentController : Controller
    {
        private DIU_App_StoreEntities db=new DIU_App_StoreEntities();

        // GET: Student
        public ActionResult Index()
        {
            var teacherCourse = db.Tbl_AssignCourse.Select(a => new VMTeacherCourse()
            {
                CID = a.CID,
                TID = a.TID,
                CourseName = a.Tbl_Course.CourseName,
                TeacherName = a.Tbl_Teacher.Tname,
                SemesterName = a.Tbl_Semester.SemesterName
            }).ToList();
            return View(teacherCourse);
        }

        public ActionResult Registation()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult Registation(Tbl_Student student )
        {
            if (ModelState.IsValid)
            {
                if (db.Tbl_Student.Any(x=>x.Stid==student.Stid || x.SuserName==student.SuserName))
                {
                    ViewBag.show = " Student already exist";
                    RedirectToAction("Registation", "Student");
                }
                else
                {
                    db.Tbl_Student.Add(student);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.show2 = student.Sname + "  Successfully Add";

                }
                
            }
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Tbl_Student student)
        {
            var log = db.Tbl_Student.Where(n => n.SuserName == student.SuserName
                            && n.Spassword == student.Spassword).FirstOrDefault();
            if (log !=null)
            {
                Session["id"] = log.SID;
                Session["name"] = log.SuserName.ToString();
               return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "User Name or Password is wrong");
            }
            return View();
        }


    }
}