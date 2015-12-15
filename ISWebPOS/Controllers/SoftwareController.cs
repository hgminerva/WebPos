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
    }
}