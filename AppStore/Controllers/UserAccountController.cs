using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AppStore.Controllers
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount

        private DbContextModels db =new DbContextModels();
      

        public ActionResult Index()
        {
            using (DbContextModels db=new DbContextModels())
            {
                return View(db.UserRegInfoModels.ToString());
            }
        }

        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reg(UserRegInfoModel acco )
        {
            if (ModelState.IsValid)
            {
                using (DbContextModels db =new DbContextModels())
                {
                    db.UserRegInfoModels.Add(acco);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = acco.uFirstName + " " + acco.uLastName + " Successfully Registered";
            }
            return View();
        }

        //login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserRegInfoModel user )
        {
            using (DbContextModels db = new DbContextModels())
            {
                var usr = db.UserRegInfoModels.Where(u =>u.UserName == user.UserName && u.uPassword == user.uPassword).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Loggined");
                }
                else
                {
                    ModelState.AddModelError("","User Name or Password is wrong");
                }
            }
            return View();
        }

        public ActionResult Loggined()
        {
            if (Session["UserId"] !=null)
            {
                return View();
            }
            else
            {
               return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost ]
        public ActionResult AdminLogin(AdminModels admin)
        {
            

            var log = db.AdminModelses.Where(u => u.UserName == admin.UserName && u.Password == admin.Password)
                .FirstOrDefault();
            
                if (log !=null)
                {
                    Session["AdminId"] = log.Id.ToString();
                    Session["AdminName"] = log.UserName.ToString();
                    return RedirectToAction("AdminHome");
                }
                else
                {
                        ModelState.AddModelError("", "User Name or Password is wrong");
                }

            return View();
        }


        //[HttpPost]
        public ActionResult AdminHome()
        {
            if (Session["AdminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }
            
        }


       
       
        

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}