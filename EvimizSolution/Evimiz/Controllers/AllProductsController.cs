using Evimiz.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evimiz.Controllers
{
    public class AllProductsController : Controller
    {
        EvimizDbContext db = new EvimizDbContext();
        // GET: items
        public ActionResult Index()
        {
          var a=  db.Product.Where(p => p.DeletedDate == null).ToList();
            return View(a);
        }
    }
}
