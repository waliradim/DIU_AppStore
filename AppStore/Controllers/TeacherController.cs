using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Web.UI.WebControls;


namespace AppStore.Controllers
{
    public class TeacherController : Controller
    {
        private DIU_App_StoreEntities db = new DIU_App_StoreEntities();
        
        // GET: Teacher
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["id"]);
            var teacherCourse = db.Tbl_AssignCourse.Where(x=>x.TID==id).Select(a => new VMTeacherCourse()
            {
                CID = a.CID,
                TID = a.TID,
                CourseName = a.Tbl_Course.CourseName,
                TeacherName = a.Tbl_Teacher.Tname,
                SemesterName = a.Tbl_Semester.SemesterName
            }).ToList();
            return View(teacherCourse);
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

            ViewBag.id = new SelectList(db.Tbl_Semester.OrderByDescending(semester =>semester.SemesterID ) , "SemesterID", "SemesterName");
            ViewBag.lvl = new SelectList(db.Tbl_Level, "LID", "LLevel");
            ViewBag.curs = new SelectList(db.Tbl_Course, "CID", "CourseName");

            return View();
        }
        [HttpGet]
        public JsonResult GetLevel()
        {
            var result = db.Tbl_Level.Select(p => new
            {
                LID = p.LID,
                LevelName = p.LLevel
            }).ToList();

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourse(int id)
        {
            var result = db.Tbl_Course.Where(c => c.Tbl_Level.Any(l => l.LID == id)).Select(c => new
            {
                CID = c.CID,
                CourseName = c.CourseName
            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCourse()
        {
            var result = db.Tbl_Course.Select(c => new
            {
                CID = c.CID,
                CourseName = c.CourseName
            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignCourse([Bind(Include = "id,TID,LID,SemesterID,CID,LastDate")] Tbl_AssignCourse asCourse)
        {

            if (ModelState.IsValid)
            {
                asCourse.TID =Convert.ToInt32( Session["id"]);
                db.Tbl_AssignCourse.Add(asCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.Tbl_Course, "CID", "CourseCode", asCourse.CID);
            ViewBag.LID = new SelectList(db.Tbl_Level, "LID", "LLevel", asCourse.LID);
            ViewBag.SemesterID = new SelectList(db.Tbl_Semester, "SemesterID", "SemesterName", asCourse.SemesterID);
            ViewBag.TID = new SelectList(db.Tbl_Teacher, "TID", "Tname", asCourse.TID);
            return View(asCourse);
            
        }

        //public ActionResult test()
        //{
        //    return View(db.Tbl_LevelCourse.ToList());
        //}

    }
}