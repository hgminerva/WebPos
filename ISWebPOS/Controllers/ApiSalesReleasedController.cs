using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiSalesReleasedController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST SalesReleased
        // ===========
        [Route("api/salesReleased/list")]
        public List<Models.TrnSalesReleased> Get()
        {
            var salesReleased = from d in db.TrnSalesReleaseds
                            select new Models.TrnSalesReleased
                            {
                                Id = d.Id,
                                SalesNumber = d.SalesNumber,
                                ItemCode = d.ItemCode,
                                ItemId = d.ItemId,
                                Quantity = d.Quantity,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = Convert.ToString(d.EntryDateTime)

                            };
            return salesReleased.ToList();
        }

        // ===========
        // ADD SalesReleased
        // ===========
        [Route("api/salesReleased/add")]
        public int Post(Models.TrnSalesReleased saleReleased)
        {
            try
            {
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;


                Data.TrnSalesReleased newSaleReleased = new Data.TrnSalesReleased();

                newSaleReleased.SalesNumber = saleReleased.SalesNumber;
                newSaleReleased.ItemCode = saleReleased.ItemCode;
                newSaleReleased.ItemId = saleReleased.ItemId;
                newSaleReleased.Quantity = saleReleased.Quantity;
                newSaleReleased.EntryUserId = mstUserId;
                newSaleReleased.EntryDateTime = date;


                db.TrnSalesReleaseds.InsertOnSubmit(newSaleReleased);
                db.SubmitChanges();

                return newSaleReleased.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE SalesReleased
        // ==============
        [Route("api/salesReleased/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnSalesReleased saleReleased)
        {
            try
            {

                var saleReleasedId = Convert.ToInt32(id);
                var salesReleaseds = from d in db.TrnSalesReleaseds where d.Id == saleReleasedId select d;

                if (salesReleaseds.Any())
                {
                    var updateSalesReleased = salesReleaseds.FirstOrDefault();

                    updateSalesReleased.SalesNumber = saleReleased.SalesNumber;
                    updateSalesReleased.ItemCode = saleReleased.ItemCode;
                    updateSalesReleased.ItemId = saleReleased.ItemId;
                    updateSalesReleased.Quantity = saleReleased.Quantity;

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
        // DELETE SalesReleased
        // ==============
        [Route("api/salesReleased/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var saleReleasedId = Convert.ToInt32(id);
                var salesReleaseds = from d in db.TrnSalesReleaseds where d.Id == saleReleasedId select d;

                if (salesReleaseds.Any())
                {
                    db.TrnSalesReleaseds.DeleteOnSubmit(salesReleaseds.First());
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