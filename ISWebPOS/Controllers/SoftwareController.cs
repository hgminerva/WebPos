using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISWebPOS.Controllers
{
    public class SoftwareController : Controller
    {
        // GET: Software
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        //Item View
        public ActionResult Item()
        {
            return View();
        }
        public ActionResult AddItem() 
        {
            return View();
        }
        public ActionResult EditItem()
        {
            return View();
        }
        //DiscountView
        public ActionResult Discount()
        {
            return View();
        }
        public  ActionResult AddDiscount()
        {
            return View();
        }
        //CustomerView
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        //SupplierView
        public ActionResult Supplier() 
        {
            return View();
        }
        public ActionResult AddSupplier()
        {
            return View();
        }
        //SystemsTableView
        public ActionResult SystemTable()
        {
            return View();
        }
        //Users View
        public ActionResult User()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }
       
    }
}