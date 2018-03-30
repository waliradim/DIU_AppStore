using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;


namespace AppStore.Controllers
{
    public class TeacherController : Controller
    {
        private DIU_App_StoreEntities db = new DIU_App_StoreEntities();
        
        // GET: Teacher
        public ActionResult Index()
        {
           
            return View();
        }


        public ActionResult TeacherReg()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherReg(Tbl_Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (db.Tbl_Teacher.Any(u => u.TEid == teacher.TEid || u.TuserName == teacher.TuserName))
                {
                    ViewBag.mas=" Teacher already exist";
                    return RedirectToAction("TeacherReg", teacher);
                }
                db.Tbl_Teacher.Add(teacher);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.mas2 = teacher.Tname + " Successfully Add";
            }
            return View();
        }


        [HttpGet]
        public ActionResult TeacherLogin()
        {
            
            return View();
        }

        [HttpPost]
        
        public ActionResult TeacherLogin(Tbl_Teacher teacher)
        {
            var log = db.Tbl_Teacher.Where(n => n.TuserName == teacher.TuserName 
                                                && n.Tpassword == teacher.Tpassword
                                                && n.IsActive == true).FirstOrDefault();
            if (log !=null)
            {
                Session["id"] = log.TID;
                Session["name"] = log.TInitial.ToString();
                return RedirectToAction("TeacherHome");
            }
            else
            {
                ModelState.AddModelError("", "User Name or Password is wrong or You are not Add as a Teacher");
            }

            return View();
        }

        
        public ActionResult TeacherHome()
        {
            return View();
        }




        public ActionResult AssignCourse()
        {
            ViewBag.id = new SelectList(db.Tbl_Semester, "SemesterID", "SemesterName");
            ViewBag.lvl= new SelectList(db.Tbl_Level,"LID","LLevel");
            ViewBag.curs = new SelectList(db.Tbl_Course,"CID","CourseName");

            return View();
        }
        [HttpPost]
        public ActionResult AssignCourse(Tbl_AssignCourse asCourse)
        {

            asCourse.TID = Convert.ToInt32(Session["id"]);
            
            var semList = db.Tbl_Semester;
            SelectList list = new SelectList(semList, "SemesterID", "SemesterName");
            ViewBag.semShow = list;

            return View();
        }

    }
}