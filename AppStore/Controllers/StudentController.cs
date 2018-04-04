using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
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
            var course = db.Tbl_AssignCourse.Select(a => new VMTeacherCourse()
            {
                CID = a.CID,
                TID = a.TID,
                 SID=a.SemesterID,
                CourseName = a.Tbl_Course.CourseName,
                TeacherName = a.Tbl_Teacher.Tname,
                SemesterName = a.Tbl_Semester.SemesterName
            }).ToList();
            return View(course);
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

        public ActionResult Submit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Submit(int cid, int sid, int tid, ProjectViewModels projView)
        {
            
                int stid = Convert.ToInt32(Session["id"]);
            
                var project = new Tbl_Project()
            {
                SID = stid,
                TID = tid,
                CID = cid,
                SemesterID = sid,
                Pname = projView.PName,
                Pdetils = projView.PDetails,

            };
            db.Tbl_Project.Add(project);
            db.SaveChanges();

            int pid = project.PID;

            var file = new Tbl_File()
            {
                PID=pid,
                Ffile1 = SaveFile(projView.Fil1),
                Ffile2 = SaveFile(projView.Fil2),
                Photo1 = SaveFile(projView.Pho1),
                Photo2 = SaveFile(projView.Pho2),
                Url = projView.Url
            };
            db.Tbl_File.Add(file);
            db.SaveChanges();
                  
                
                return View();
            
        }

        


        private string SaveFile(HttpPostedFileBase file1)
        {
            
                if (file1.ContentLength > 0)
            {
                var fileName =Path.GetFileName(file1.FileName);
                var path = Path.Combine(Server.MapPath("~/UplodeFile"), fileName);
                file1.SaveAs(path);
                return path;
            }
                else
                {
                    RedirectToAction("Index");
                }


            return string.Empty;
        }
        
    }
}