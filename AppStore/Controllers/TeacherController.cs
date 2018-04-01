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

            ViewBag.id = new SelectList(db.Tbl_Semester.OrderByDescending(semester =>semester.SemesterID ) , "SemesterID", "SemesterName");
            ViewBag.lvl = new SelectList(db.Tbl_Level, "LID", "LLevel");
            ViewBag.curs = new SelectList(db.Tbl_Course, "CID", "CourseName");

            return View();
        }

        public JsonResult GetLevel()
        {
            var lvl = (from lv in db.Tbl_Level
                join av in db.Tbl_LevelCourse
                    on lv.LID equals av.LID
                select new  { name=lv.LLevel, valu=av.LID }).ToList().OrderBy(x=>x.name);
            return Json(lvl,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourse(int id)
        {
            var cor = (from c in db.Tbl_Course
                join b in db.Tbl_LevelCourse
                    on c.CID equals b.CID
                where b.LID == id
                select new {name = c.CourseName, valu = b.CID}).ToList().OrderBy(x => x.name);
            return Json(cor);
        }

        [HttpPost]
        public ActionResult AssignCourse([Bind(Include = "id,TID,LID,SemesterID,CID")] Tbl_AssignCourse asCourse)
        {

            if (ModelState.IsValid)
            {
                //tbl_AssignCourse.TID = 1;
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