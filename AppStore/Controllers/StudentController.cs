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
                SemesterName = a.Tbl_Semester.SemesterName,
               
            }).ToList();
            return View(course);
        }

        public ActionResult ProjectList()
        {
            var ProjectList = db.Tbl_Project.ToList();

            return View();
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

        [HttpGet]
        public ActionResult Submit(int cid, int sid, int tid)
        {
            ViewBag.CID = cid;
            ViewBag.SemId = sid;
            ViewBag.TID = tid;
            return View();
        }


        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(ProjectViewModels projView)
        {
            
                int stid = Convert.ToInt32(Session["id"]);
            //int cid = ViewBag.CID;
            //int sid = ViewBag.SID;
            //int tid = ViewBag.TID;
            var project = new Tbl_Project()
            {
                SID = stid,
                TID =projView.Tid ,
                CID = projView.Cid,
                SemesterID = projView.Sid,
                Pname = projView.PName,
                Pdetils = projView.PDetails,

            };
            db.Tbl_Project.Add(project);
            db.SaveChanges();


            //var fileName = Path.GetFileName(Fil1.FileName);
            //var path = Path.Combine(Server.MapPath("~/UplodeFile/") + fileName);
            //Fil1.SaveAs(path);

            int pid = project.PID;

            var file = new Tbl_File()
            {
                PID=pid,
                Ffile1 = SaveFile1((projView.ProjectReport[0])),
                Ffile2 = SaveFile1(projView.ProjectFile[0]),
                Photo1 = SaveFile1(projView.ProjectScreenshot1[0]),
                Photo2 = SaveFile1(projView.ProjectScreenshot2[0]),
                Url = projView.Url
            };
            db.Tbl_File.Add(file);
            db.SaveChanges();

            

            return RedirectToAction("Index","Project");
            //RedirectToAction("Index");

        }

        


        private string SaveFile1( HttpPostedFileBase file1)
        {
            //try
            //{
                
                if (file1 != null && file1.ContentLength > 0)
                {

                //    var path1 = Path.Combine(Server.MapPath("~/UplodeFile/"), Path.GetFileName(Guid.NewGuid().ToString() + file1.FileName));
                //file1.SaveAs(path1);


                var fileName = Path.GetFileName(Guid.NewGuid().ToString() + file1.FileName);
                var path = "~/UplodeFile/" + fileName;
                file1.SaveAs(Server.MapPath(path));
                return path;
                }
            
            
            return string.Empty;
        }

        private string SaveFile2(HttpPostedFileBase file2)
        {
           
                if (file2 != null && file2.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Guid.NewGuid().ToString()+ file2.FileName);
                var path = Path.Combine(Server.MapPath("~/UplodeFile/")+fileName);
                file2.SaveAs(path);
                return path;
            }

            return string.Empty;
        }

        private string SaveFile3( HttpPostedFileBase Pho1)
        {

            if (Pho1 != null && Pho1.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Pho1.FileName);
                var path = Path.Combine(Server.MapPath("~/UplodeFile/")+ fileName);
                Pho1.SaveAs(path);
                return path;
            }

            return string.Empty;
        }


        private string SaveFile4( HttpPostedFileBase Pho2)
        {

            if (Pho2 != null && Pho2.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Pho2.FileName);
                var path = Path.Combine(Server.MapPath("~/UplodeFile/")+ fileName);
                Pho2.SaveAs(path);
                return path;
            }

            return string.Empty;
        }



        //end backet work 
    }
}