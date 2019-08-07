using Evimiz.Models.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Evimiz.Areas.Manager.Controllers
{
    [AuthorizeAdminFilter]
    public class ProductController : Controller
    {
        private readonly EvimizDbContext db = new EvimizDbContext();
        // GET: Manager/Product
        public ActionResult Index()
        {
            var pr = db.Product.Where(p => p.DeletedDate == null).ToList();

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_PruductListPartial.cshtml", pr);
            }

            return View(pr);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult CreateProduct()
        {

            ViewBag.SubCategoryId = new SelectList(db.Subcategory.Where(s=>s.DeletedDate==null), "Id", "Name");
            ViewBag.ColorId = new SelectList(db.Color.Where(s => s.DeletedDate == null), "Id", "Name");
            ViewBag.BrandId = new SelectList(db.Brand.Where(s => s.DeletedDate == null), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase PhotoPath1, HttpPostedFileBase PhotoPath2,
            HttpPostedFileBase PhotoPath3, HttpPostedFileBase PhotoPath4, HttpPostedFileBase PhotoPath5)
        {
            if (PhotoPath1 == null)
            {
                ModelState.AddModelError("photo1", "Şəkil seçilməyib!");
            }
            else
            {
                if (!PhotoPath1.CheckImageType())
                {
                    ModelState.AddModelError("PhotoPath1", "Şəkil uyğun deyil!");
                }

                if (!PhotoPath1.CheckImageSize(5))
                {
                    ModelState.AddModelError("PhotoPath1", "Şəklin ölçüsü uyğun deyil!");
                }
            }

            if (PhotoPath2 != null)
            {
                if (!PhotoPath2.CheckImageType())
                {
                    ModelState.AddModelError("PhotoPath2", "Şəkil uyğun deyil!");
                }

                if (!PhotoPath2.CheckImageSize(5))
                {
                    ModelState.AddModelError("PhotoPath2", "Şəklin ölçüsü uyğun deyil!");
                }
            }
            if (PhotoPath3 != null)
            {
                if (!PhotoPath3.CheckImageType())
                {
                    ModelState.AddModelError("PhotoPath3", "Şəkil uyğun deyil!");
                }

                if (!PhotoPath3.CheckImageSize(5))
                {
                    ModelState.AddModelError("PhotoPath3", "Şəklin ölçüsü uyğun deyil!");
                }
            }
            if (PhotoPath4 != null)
            {
                if (!PhotoPath4.CheckImageType())
                {
                    ModelState.AddModelError("PhotoPath4", "Şəkil uyğun deyil!");
                }

                if (!PhotoPath4.CheckImageSize(5))
                {
                    ModelState.AddModelError("PhotoPath4", "Şəklin ölçüsü uyğun deyil!");
                }
            }
            if (PhotoPath5 != null)
            {
                if (!PhotoPath5.CheckImageType())
                {
                    ModelState.AddModelError("PhotoPath5", "Şəkil uyğun deyil!");
                }

                if (!PhotoPath5.CheckImageSize(5))
                {
                    ModelState.AddModelError("PhotoPath5", "Şəklin ölçüsü uyğun deyil!");
                }
            }

            if (ModelState.IsValid)
            {
                product.PhotoPath1 = PhotoPath1.SaveImage(Server.MapPath("~/Areas/media"));
                if (PhotoPath2 != null)
                {
                    product.PhotoPath2 = PhotoPath2.SaveImage(Server.MapPath("~/Areas/media"));
                }
                if (PhotoPath3 != null)
                {
                    product.PhotoPath3 = PhotoPath3.SaveImage(Server.MapPath("~/Areas/media"));
                }
                if (PhotoPath4 != null)
                {
                    product.PhotoPath4 = PhotoPath4.SaveImage(Server.MapPath("~/Areas/media"));
                }
                if (PhotoPath5 != null)
                {
                    product.PhotoPath5 = PhotoPath5.SaveImage(Server.MapPath("~/Areas/media"));
                }



                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();


        }

        [HttpGet]
        public ActionResult Sale(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product col = db.Product.Find(id);
            if (col == null)
            {
                return HttpNotFound();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Manager/Views/Partials/_SaleProductPartial.cshtml", col);
            }
            return View(col);
        }
        [HttpPost]
        public ActionResult Sale(Product product, double? percent)
        {
            var pr = db.Product.Where(p => p.DeletedDate == null).ToList();
            var entity = db.Product.Find(product.Id);
            if (percent==null && product.SaledPrice==null)
            {

                ViewBag.Error = "Siz ya faizlə ya da qiymətlə endirim edə bilərsiniz, hır ikisindən eyni vaxtda istifadə etmək mümkün deyil";
                return View("Index",pr);
            }

            if (percent != null && product.SaledPrice != null)
            {
                ViewBag.Error = "Zəhmət olmasa ya neçə faiz endirim etmək istədiyinii ya da qiyməti yazın";
                return View("Index",pr);
            }
            if (percent != null && product.SaledPrice==null)
            {
                entity.SaledPrice =product.Price-( (product.Price * percent) / 100);
                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();

                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                return RedirectToAction("Index");
            }

            if (product.SaledPrice != null && percent==null)
            {
                entity.SaledPrice = product.SaledPrice;
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {

            ViewBag.SubCategoryId = new SelectList(db.Subcategory, "Id", "Name");
            ViewBag.ColorId = new SelectList(db.Color, "Id", "Name");
            ViewBag.BrandId = new SelectList(db.Brand, "Id", "Name");

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Product pro = db.Product.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase PhotoPath1, HttpPostedFileBase PhotoPath2,
            HttpPostedFileBase PhotoPath3, HttpPostedFileBase PhotoPath4, HttpPostedFileBase PhotoPath5,string filename)
        {
            return View();
        }
    }


}