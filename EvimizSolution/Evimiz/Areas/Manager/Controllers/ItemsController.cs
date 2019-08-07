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
    public class ItemsController : Controller
    {
        readonly EvimizDbContext db = new EvimizDbContext();

        //Category
        public ActionResult Category()
        {
            var cat = db.Category.Where(c => c.DeletedDate == null).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_CategoryListPartial.cshtml", cat);
            }
            return View(cat);
        }


        [HttpPost]
        public ActionResult CreateNewCategory(Category category)
        {
           var categories = db.Category.ToList();
            db.Category.Add(category);
            db.SaveChanges();
            return RedirectToAction("Category", "Items");
        }
        
        [HttpGet]
        public ActionResult EditCategory(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Category cat = db.Category.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_EditCategory.cshtml", cat);
            }
            return View(cat);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {

            Category entity = db.Category.Find(category.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Name = category.Name;
                entity.Description = category.Description;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Category","Items");
        }


        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Category category = db.Category.Find(id);
            if (category == null)
                return HttpNotFound();

            category.DeletedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Category","Items");
        }




        //SubCategory

        public ActionResult SubCategory()
        {
            ViewBag.CategoryId = new SelectList(db.Category.Where(c=>c.DeletedDate==null), "Id", "Name");
            var scat = db.Subcategory.Where(c => c.DeletedDate == null).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_CategoryListPartial.cshtml", scat);
            }
            return View(scat);
        }
        [HttpPost]
        public ActionResult CreateNewSubCategory(SubCategory category)
        {
            var categories = db.Subcategory.ToList();
            db.Subcategory.Add(category);

              db.SaveChanges();
            return RedirectToAction("SubCategory", "Items");
        }

        [HttpGet]
        public ActionResult EditSubCategory(int? id)
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "Name");


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SubCategory cat = db.Subcategory.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_EditSubcategoryPartial.cshtml", cat);
            }
            return View(cat);
        }

        [HttpPost]
        public ActionResult EditSubCategory(SubCategory category)
        {
            var scat = db.Subcategory.Where(c => c.DeletedDate == null).ToList();

            SubCategory entity = db.Subcategory.Find(category.Id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                entity.Name = category.Name;
                entity.Description = category.Description;
                entity.CategoryId = category.CategoryId;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return View("SubCategory",scat);
            }
            return RedirectToAction("SubCategory",scat);


        }


        public ActionResult DeleteSubCategory(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            SubCategory category = db.Subcategory.Find(id);
            if (category == null)
                return HttpNotFound();

            category.DeletedDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("SubCategory", "Items");
        }

    }
}
