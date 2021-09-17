using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStockApplication.Models.Entity;

namespace MvcStockApplication.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewOrder(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return View("Index");
        }
    }
}