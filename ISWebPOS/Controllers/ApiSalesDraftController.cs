using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiSalesDraftController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST SalesDraft
        // ===========
        [Route("api/salesDraft/list")]
        public List<Models.TrnSalesDraft> Get()
        {
            var salesDraft = from d in db.TrnSalesDrafts
                        select new Models.TrnSalesDraft
                        {
                            Id = d.Id,
                            DocRef = d.DocRef,
                            DocDate = Convert.ToString(d.DocDate),
                            ItemCode = d.ItemCode,
                            ItemId = d.ItemId,
                            Price = d.Price,
                            Quantity = d.Quantity,
                            Amount = d.Amount,
                            CustomerCode = d.CustomerCode,
                            Customer = d.Customer,
                            ContactPerson = d.ContactPerson,
                            Address = d.Address,
                            PhoneNumber = d.PhoneNumber,
                            MobilePhoneNumber = d.MobilePhoneNumber

                        };
            return salesDraft.ToList();
        }

        // ===========
        // ADD SalesDraft
        // ===========
        [Route("api/salesDraft/add")]
        public int Post(Models.TrnSalesDraft salesDraft)
        {
            try
            {
                

                Data.TrnSalesDraft newSalesDraft = new Data.TrnSalesDraft();

                newSalesDraft.DocRef = salesDraft.DocRef;
                newSalesDraft.DocDate = Convert.ToDateTime(salesDraft.DocDate);
                newSalesDraft.ItemCode = salesDraft.ItemCode;
                newSalesDraft.ItemId = salesDraft.ItemId;
                newSalesDraft.Price = salesDraft.Price;
                newSalesDraft.Quantity = salesDraft.Quantity;
                newSalesDraft.Amount = salesDraft.Amount;
                newSalesDraft.CustomerCode = salesDraft.CustomerCode;
                newSalesDraft.Customer = salesDraft.Customer;
                newSalesDraft.ContactPerson = salesDraft.ContactPerson;
                newSalesDraft.Address = salesDraft.Address;
                newSalesDraft.PhoneNumber = salesDraft.PhoneNumber;
                newSalesDraft.MobilePhoneNumber = salesDraft.MobilePhoneNumber;


                db.TrnSalesDrafts.InsertOnSubmit(newSalesDraft);
                db.SubmitChanges();

                return newSalesDraft.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE SalesDraft
        // ==============
        [Route("api/salesDraft/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnSalesDraft salesDraft)
        {
            try
            {
                

                var salesDraftId = Convert.ToInt32(id);
                var salesDrafts = from d in db.TrnSalesDrafts where d.Id == salesDraftId select d;

                if (salesDrafts.Any())
                {
                    var updateSalesDraft = salesDrafts.FirstOrDefault();

                    updateSalesDraft.DocRef = salesDraft.DocRef;
                    updateSalesDraft.DocDate = Convert.ToDateTime(salesDraft.DocDate);
                    updateSalesDraft.ItemCode = salesDraft.ItemCode;
                    updateSalesDraft.ItemId = salesDraft.ItemId;
                    updateSalesDraft.Price = salesDraft.Price;
                    updateSalesDraft.Quantity = salesDraft.Quantity;
                    updateSalesDraft.Amount = salesDraft.Amount;
                    updateSalesDraft.CustomerCode = salesDraft.CustomerCode;
                    updateSalesDraft.Customer = salesDraft.Customer;
                    updateSalesDraft.ContactPerson = salesDraft.ContactPerson;
                    updateSalesDraft.Address = salesDraft.Address;
                    updateSalesDraft.PhoneNumber = salesDraft.PhoneNumber;
                    updateSalesDraft.MobilePhoneNumber = salesDraft.MobilePhoneNumber;

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
        // DELETE SalesDraft
        // ==============
        [Route("api/salesDraft/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var saleDraftId = Convert.ToInt32(id);
                var salesDrafts = from d in db.TrnSalesDrafts where d.Id == saleDraftId select d;

                if (salesDrafts.Any())
                {
                    db.TrnSalesDrafts.DeleteOnSubmit(salesDrafts.First());
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