using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStockApplication.Models.Entity;

namespace MvcStockApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var values = from v in db.Customer select v;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.CustomerName.Contains(p));
            }
            return View(values.ToList());
            //var values = db.Customer.ToList();
            //return View(values);
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customer customer1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
            db.Customer.Add(customer1);
            db.SaveChanges();
            return RedirectToAction("Index");     
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult UpdateCustomer(Customer customer)
        {
            var c = db.Customer.Find(customer.CustomerId);
            c.CustomerName = customer.CustomerName;
            c.CustomerSurname = customer.CustomerSurname;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}