using Evimiz.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Evimiz.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        EvimizDbContext db = new EvimizDbContext();

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (db.User.Where(u=>u.Email==user.Email).FirstOrDefault()!=null)
            {
                ViewBag.LoginError = "Bu E-poçt artıq qeydiyyatdan keçib";
                return RedirectToAction("Index", "Home");
            }
            if (user.FullName ==null  && user.Email==null && user.PhoneNumber==null )
            {
                ViewBag.LoginError = "Boş sahələri doldurun.";
                return RedirectToAction("Index", "Home");
            }
            user.Password = Crypto.HashPassword(user.Password);

            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            db.User.Add(user);
            db.SaveChanges();
            Session[SessionKey.UserSession] = user;
            ViewBag.UserName = user.FullName;
            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {

            if (Email == null)
            {
                ViewBag.LoginError = "Boş sahələri doldurun.";
                return View("Index");
            }
            if (Password == null)
            {
                ViewBag.LoginError = "Boş sahələri doldurun.";
                return RedirectToAction("Index", "Home");
            }
            User LoggedUser = db.User.Where(a => a.Email == Email).FirstOrDefault();
            if (LoggedUser != null && Crypto.VerifyHashedPassword(LoggedUser.Password, Password))
            {
                Session[SessionKey.UserSession] = LoggedUser;
                Session[SessionKey.UserSessionName] = LoggedUser.FullName;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.LoginError = "E-poçt və ya şifrə yalnışdır";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}