using Evimiz.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evimiz.Controllers
{
    public class HomeController : Controller
    {
        readonly EvimizDbContext db = new EvimizDbContext();

        public ActionResult Index()
        {
            
            return View(db.Product.Where(p=>p.DeletedDate==null).ToList());
        }

        public ActionResult SinglePost(int id)
        {
            var post = db.Product.Find(id);
            return View(post);
        }
    }


}