using Evimiz.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Evimiz.Areas.Manager.Controllers
{
    [AuthorizeAdminFilter]
    public class FilterController : Controller
    {
        readonly EvimizDbContext db = new EvimizDbContext();
        // GET: Manager/Filter
        [Authorize]
        public ActionResult Colors()
        {
            var col = db.Color.Where(c => c.DeletedDate == null).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_ColorListPartial.cshtml",col);
            }
            return View(col);
        }
      
       public ActionResult CreateColor(Color color)
        {
            db.Color.Add(color);
            db.SaveChanges();
            return RedirectToAction("Colors","Filter");
        }

        [HttpGet]
        public ActionResult EditColor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Color col = db.Color.Find(id);
            if (col == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_EditColorPartial.cshtml", col);
            }
            return View(col);
        }

        [HttpPost]
        public ActionResult EditColor(Color color)
        {
            Color entity = db.Color.Find(color.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Name = color.Name;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Colors", "Filter");
        }


        [Authorize]
        public ActionResult DeleteColor(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Color col = db.Color.Find(id);
            if (col == null)
                return HttpNotFound();

            col.DeletedDate = DateTime.Now;
            db.Entry(col).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Colors", "Filter");
        }



        //Marka
        public ActionResult Brands()
        {
            var brand = db.Brand.Where(c => c.DeletedDate == null).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_BrandsListPartial.cshtml", brand);
            }
            return View(brand);
        }

        public ActionResult CreateBrand(Brand brand)
        {
            db.Brand.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Brands", "Filter");
        }

        [HttpGet]
        public ActionResult EditBrand(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_EditBrandPartial.cshtml", brand);
            }
            return View(brand);
        }

        [HttpPost]
        public ActionResult EditBrand(Brand brand)
        {
            Brand entity = db.Brand.Find(brand.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Name = brand.Name;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Brands", "Filter");
        }

        public ActionResult DeleteBrand(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Brand brand = db.Brand.Find(id);
            if (brand == null)
                return HttpNotFound();

            brand.DeletedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Brands", "Filter");
        }
    }
}