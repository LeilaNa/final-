using Evimiz.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Evimiz.Areas.Manager.Controllers
{
    public class ManagerAccountController : Controller
    {
        readonly EvimizDbContext db = new EvimizDbContext();
        // GET: Manager/ManagerAccount
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            if (Email == null)
            {
                ViewBag.LoginError = "Boş sahələri doldurun.";
                return View();
            }
            if (Password == null)
            {
                ViewBag.LoginError = "Boş sahələri doldurun.";
                return View();
            }
            Admin LoggedUser = db.Admin.Where(a => a.Email == Email).FirstOrDefault();
            if (LoggedUser != null && Crypto.VerifyHashedPassword(LoggedUser.Password, Password))
            {
                Session[SessionKey.AdminSession] = LoggedUser;
                return RedirectToAction("Category","Items");
            }
            ViewBag.LoginError = "E-poçt və ya şifrə yalnışdır";
            return View();

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login","ManagerAccount",new { Area = "Manager" });
        }
    }
}