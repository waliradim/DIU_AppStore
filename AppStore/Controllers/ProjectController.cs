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
    public class ProjectController : Controller
    {
        private DIU_App_StoreEntities db = new DIU_App_StoreEntities();
        // private ProjectViewModels pro=new ProjectViewModels();
        //int cid,int sid,int tid, ProjectViewModels proj
       
    // GET: Project
    public ActionResult Index()
        {
            var tbl_File = db.Tbl_File.Include(t => t.Tbl_Project);
            return View(tbl_File.ToList());
        }


        public ActionResult Insert()
        {

            return View();
        }


        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_File tbl_File = db.Tbl_File.Find(id);
            if (tbl_File == null)
            {
                return HttpNotFound();
            }
            return View(tbl_File);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.PID = new SelectList(db.Tbl_Project, "PID", "Pname");
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FID,PID,Ffile1,Ffile2,Photo1,Photo2,Url")] Tbl_File tbl_File)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_File.Add(tbl_File);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PID = new SelectList(db.Tbl_Project, "PID", "Pname", tbl_File.PID);
            return View(tbl_File);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_File tbl_File = db.Tbl_File.Find(id);
            if (tbl_File == null)
            {
                return HttpNotFound();
            }
            ViewBag.PID = new SelectList(db.Tbl_Project, "PID", "Pname", tbl_File.PID);
            return View(tbl_File);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FID,PID,Ffile1,Ffile2,Photo1,Photo2,Url")] Tbl_File tbl_File)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_File).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PID = new SelectList(db.Tbl_Project, "PID", "Pname", tbl_File.PID);
            return View(tbl_File);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_File tbl_File = db.Tbl_File.Find(id);
            if (tbl_File == null)
            {
                return HttpNotFound();
            }
            return View(tbl_File);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_File tbl_File = db.Tbl_File.Find(id);
            db.Tbl_File.Remove(tbl_File);
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
