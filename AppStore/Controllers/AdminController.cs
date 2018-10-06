using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;
using System.Data.SqlClient;

namespace AppStore.Controllers
{
    public class AdminController : Controller
    {
        private DIU_App_StoreEntities db=new DIU_App_StoreEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Tbl_Course course)
        {
            if (ModelState.IsValid)
            {
                if (db.Tbl_Course.Any(u=>u.CourseCode==course.CourseCode))
                {
                    ViewBag.DuplicateMessage = " Course Code already exist";
                    return View("AddCourse",course);
                }
                db.Tbl_Course.Add(course);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = course.CourseCode + "  " + course.CourseName + "  Successfully Add";
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddSemester()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSemester(Tbl_Semester semester)
        {
            if (ModelState.IsValid)
            {
                if (db.Tbl_Semester.Any(u=>u.SemesterName==semester.SemesterName))
                {
                    ViewBag.SemesterDuplicate= " Semester already exist";
                    return View("AddSemester", semester);
                }

                db.Tbl_Semester.Add(semester);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = semester.SemesterName+" Successfully Add";

            }
            return View();
        }

        public ActionResult ViewCourse()
        {

            return View(db.Tbl_Course.ToList());
        }

        public ActionResult ViewSemester()
        {

            return View(db.Tbl_Semester.ToList());
        }

        
        public ActionResult TeacherAdd(Tbl_Teacher teacher)
        {
            //List<Tbl_Teacher> teacherList =db.Tbl_Teacher.Where(u=>u.IsActive) ;
            //var tcrList = db.Tbl_Teacher.Where(teacher.IsActive=false).ToString();
            var tcrList = from tcr in db.Tbl_Teacher where tcr.IsActive == false select tcr;
            return View(tcrList);
        }

        public ActionResult TeacherAproval(int id, Tbl_Teacher teacher)
        {
            Tbl_Teacher tcr = db.Tbl_Teacher.Single(u => u.TID == id);
            tcr.IsActive = true;
            //db.Tbl_Teacher.Add(teacher);
            db.SaveChanges();
            

            return RedirectToAction("TeacherAdd");
        }

        public ActionResult TecherDelete(int id, Tbl_Teacher teacher)
        {
            Tbl_Teacher tcr = db.Tbl_Teacher.Single(x => x.TID == id);
            db.Tbl_Teacher.Remove(tcr);
            db.SaveChanges();

            return RedirectToAction("TeacherAdd");
        }
    }
}