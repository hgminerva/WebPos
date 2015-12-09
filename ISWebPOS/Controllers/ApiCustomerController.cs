using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiCustomerController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Customer
        // ===========
        [Route("api/customer/list")]
        public List<Models.MstCustomer> Get()
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
                               TIN  = d.TIN,
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
            return customer.ToList();
        }

        // ===========
        // ADD Customer
        // ===========
        [Route("api/customer/add")]
        public int Post(Models.MstCustomer customer)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstCustomer newCustomer = new Data.MstCustomer();

                newCustomer.Customer = customer.Customer;
                newCustomer.Address = customer.Address;
                newCustomer.ContactPerson = customer.ContactPerson;
                newCustomer.ContactNumber = customer.ContactNumber;
                newCustomer.CreditLimit = customer.CreditLimit;
                newCustomer.TermId = customer.TermId;
                newCustomer.TIN  = customer.TIN;
                newCustomer.WithReward = customer.WithReward;
                newCustomer.RewardNumber = customer.RewardNumber;
                newCustomer.RewardConversion = customer.RewardConversion;
                newCustomer.AccountId = customer.AccountId;
                newCustomer.DefaultPriceDescription = customer.DefaultPriceDescription;

                newCustomer.EntryUserId = mstUserId;
                newCustomer.EntryDateTime = date;
                newCustomer.UpdateUserId = mstUserId;
                newCustomer.UpdateDateTime = date;
                newCustomer.IsLocked = isLocked;    

                db.MstCustomers.InsertOnSubmit(newCustomer);
                db.SubmitChanges();

                return newCustomer.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Customer
        // ==============
        [Route("api/customer/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstCustomer customer)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var cusomerId = Convert.ToInt32(id);
                var customers = from d in db.MstCustomers where d.Id == cusomerId select d;

                if (customers.Any())
                {
                    var updateCustomer = customers.FirstOrDefault();

                    updateCustomer.Customer = customer.Customer;
                    updateCustomer.Address = customer.Address;
                    updateCustomer.ContactPerson = customer.ContactPerson;
                    updateCustomer.ContactNumber = customer.ContactNumber;
                    updateCustomer.CreditLimit = customer.CreditLimit;
                    updateCustomer.TermId = customer.TermId;
                    updateCustomer.TIN = customer.TIN;
                    updateCustomer.WithReward = customer.WithReward;
                    updateCustomer.RewardNumber = customer.RewardNumber;
                    updateCustomer.RewardConversion = customer.RewardConversion;
                    updateCustomer.AccountId = customer.AccountId;
                    updateCustomer.DefaultPriceDescription = customer.DefaultPriceDescription;

                    updateCustomer.UpdateUserId = mstUserId;
                    updateCustomer.UpdateDateTime = date;
                    updateCustomer.IsLocked = isLocked;

                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // ==============
        // DELETE Customer
        // ==============
        [Route("api/customer/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var customerId = Convert.ToInt32(id);
                var customers = from d in db.MstCustomers where d.Id == customerId select d;

                if (customers.Any())
                {
                    db.MstCustomers.DeleteOnSubmit(customers.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
