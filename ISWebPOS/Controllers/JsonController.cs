using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISWebPOS.Controllers
{
    public class JsonController : Controller
    {
        private Data.webposDataContext db = new Data.webposDataContext();
        // GET: Json
        public ActionResult Index()
        {
            var isLocked = true;

            var customer = from d in db.MstCustomers
                           select new Models.MstCustomer
                           {
                               Customer = d.Customer,
                               Address = d.Address,
                               ContactPerson = d.ContactPerson,
                               ContactNumber = d.ContactNumber,
                               CreditLimit = d.CreditLimit,
                               TermId = d.TermId,
                               TIN = d.TIN,
                               WithReward = d.WithReward,
                               RewardNumber = d.RewardNumber,
                               RewardConversion = d.RewardConversion,
                               AccountId = d.AccountId,
                               DefaultPriceDescription = d.DefaultPriceDescription,

                               EntryUserId = d.EntryUserId,
                               EntryDateTime = d.EntryDateTime,
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = d.UpdateDateTime,
                               IsLocked = isLocked
                           };
            return Json(customer,JsonRequestBehavior.AllowGet);
        }
    }
}