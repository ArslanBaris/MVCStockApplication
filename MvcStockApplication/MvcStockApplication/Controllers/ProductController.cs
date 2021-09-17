using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStockApplication.Models.Entity;

namespace MvcStockApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();    
        public ActionResult Index()
        {
            var values = db.Product.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from i in db.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value=i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.val = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("NewProduct");
            }
            var category = db.Category.Where(m => m.CategoryId == product.Category.CategoryId).FirstOrDefault();
            product.Category = category;
            db.Product.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index"); ;

        }

        public ActionResult DeleteProduct(int id)
        {
            var product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            var product = db.Product.Find(id);
            List<SelectListItem> values = (from i in db.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.val = values;
            return View("GetProduct", product);
        }

        public ActionResult UpdateProduct1(Product product)
        {
            var p = db.Product.Find(product.ProductId);
            p.ProductName = product.ProductName;
            p.Brand = product.Brand;
            var category = db.Category.Where(m => m.CategoryId == product.Category.CategoryId).FirstOrDefault();
            p.ProductCategory = category.CategoryId;
            p.UnitPrice = product.UnitPrice;
            p.Stock = product.Stock;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}