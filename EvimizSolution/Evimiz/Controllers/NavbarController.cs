using Evimiz.Models.Entity;
using Evimiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evimiz.Controllers
{
    public class NavbarController : Controller
    {
        EvimizDbContext db = new EvimizDbContext();
        // GET: Navbar
        [ChildActionOnly]
        public ActionResult Index()
        {
            NavBarViewModel VM = new NavBarViewModel()
            {
                Product = db.Product.Where(p => p.DeletedDate == null).ToList(),
                SubCategory = db.Subcategory.Where(p => p.DeletedDate == null).ToList(),
                Category = db.Category.Where(p => p.DeletedDate == null).ToList()
            };
            return View(VM);
        }

        [ChildActionOnly]
        public ActionResult Mobile()
        {
            NavBarViewModel VM = new NavBarViewModel()
            {
                Product = db.Product.Where(p => p.DeletedDate == null).ToList(),
                SubCategory = db.Subcategory.Where(p => p.DeletedDate == null).ToList(),
                Category = db.Category.Where(p => p.DeletedDate == null).ToList()
            };
            return View(VM);
        }
    }
}