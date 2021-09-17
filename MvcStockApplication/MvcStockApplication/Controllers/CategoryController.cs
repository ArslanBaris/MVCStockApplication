using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStockApplication.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStockApplication.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int page=1)
        {
            //var values = db.Category.ToList();
            var values = db.Category.ToList().ToPagedList(page, 4);  // kacinci sayfadan okunmaya baslar,her sayfada kac deger 
            return View(values);
        }

        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Category.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetCategory(int id)
        {
            var category = db.Category.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult UpdateCategory(Category category)
        {
            var ct = db.Category.Find(category.CategoryId);
            ct.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}