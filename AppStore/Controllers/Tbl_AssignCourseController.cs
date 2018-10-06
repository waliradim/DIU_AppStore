using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;

namespace AppStore.Controllers
{
    public class Tbl_AssignCourseController : Controller
    {
        private DIU_App_StoreEntities db = new DIU_App_StoreEntities();

        // GET: Tbl_AssignCourse
        public ActionResult Index()
        {
            var tbl_AssignCourse = db.Tbl_AssignCourse.Include(t => t.Tbl_Course).Include(t => t.Tbl_Level).Include(t => t.Tbl_Semester).Include(t => t.Tbl_Teacher);
            return View(tbl_AssignCourse.ToList());
        }

        // GET: Tbl_AssignCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_AssignCourse tbl_AssignCourse = db.Tbl_AssignCourse.Find(id);
            if (tbl_AssignCourse == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AssignCourse);
        }

        // GET: Tbl_AssignCourse/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(db.Tbl_Course, "CID", "CourseCode");
            ViewBag.LID = new SelectList(db.Tbl_Level, "LID", "LLevel");
            ViewBag.SemesterID = new SelectList(db.Tbl_Semester, "SemesterID", "SemesterName");
            ViewBag.TID = new SelectList(db.Tbl_Teacher, "TID", "Tname");
            return View();
        }

        // POST: Tbl_AssignCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TID,LID,SemesterID,CID,LastDate")] Tbl_AssignCourse tbl_AssignCourse)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_AssignCourse.Add(tbl_AssignCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.Tbl_Course, "CID", "CourseCode", tbl_AssignCourse.CID);
            ViewBag.LID = new SelectList(db.Tbl_Level, "LID", "LLevel", tbl_AssignCourse.LID);
            ViewBag.SemesterID = new SelectList(db.Tbl_Semester, "SemesterID", "SemesterName", tbl_AssignCourse.SemesterID);
            ViewBag.TID = new SelectList(db.Tbl_Teacher, "TID", "Tname", tbl_AssignCourse.TID);
            return View(tbl_AssignCourse);
        }

        // GET: Tbl_AssignCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_AssignCourse tbl_AssignCourse = db.Tbl_AssignCourse.Find(id);
            if (tbl_AssignCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(db.Tbl_Course, "CID", "CourseCode", tbl_AssignCourse.CID);
            ViewBag.LID = new SelectList(db.Tbl_Level, "LID", "LLevel", tbl_AssignCourse.LID);
            ViewBag.SemesterID = new SelectList(db.Tbl_Semester, "SemesterID", "SemesterName", tbl_AssignCourse.SemesterID);
            ViewBag.TID = new SelectList(db.Tbl_Teacher, "TID", "Tname", tbl_AssignCourse.TID);
            return View(tbl_AssignCourse);
        }

        // POST: Tbl_AssignCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TID,LID,SemesterID,CID,LastDate")] Tbl_AssignCourse tbl_AssignCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_AssignCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.Tbl_Course, "CID", "CourseCode", tbl_AssignCourse.CID);
            ViewBag.LID = new SelectList(db.Tbl_Level, "LID", "LLevel", tbl_AssignCourse.LID);
            ViewBag.SemesterID = new SelectList(db.Tbl_Semester, "SemesterID", "SemesterName", tbl_AssignCourse.SemesterID);
            ViewBag.TID = new SelectList(db.Tbl_Teacher, "TID", "Tname", tbl_AssignCourse.TID);
            return View(tbl_AssignCourse);
        }

        // GET: Tbl_AssignCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_AssignCourse tbl_AssignCourse = db.Tbl_AssignCourse.Find(id);
            if (tbl_AssignCourse == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AssignCourse);
        }

        // POST: Tbl_AssignCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_AssignCourse tbl_AssignCourse = db.Tbl_AssignCourse.Find(id);
            db.Tbl_AssignCourse.Remove(tbl_AssignCourse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
