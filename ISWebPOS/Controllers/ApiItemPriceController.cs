using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemPriceController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Item Price
        // ===========
        [Route("api/itemPrice/list")]
        public List<Models.MstItemPrice> Get()
        {
            var itemPrices = from d in db.MstItemPrices
                            select new Models.MstItemPrice
                           {
                               Id = d.Id,
                               ItemId = d.ItemId,
                               PriceDescription= d.PriceDescription,
                               Price = d.Price,
                               TriggerQuantity = d.TriggerQuantity
                           };
            return itemPrices.ToList();
        }

        // ===========
        // ADD Item Price
        // ===========
        [Route("api/itemPrice/add")]
        public int Post(Models.MstItemPrice itemPrice)
        {
            try
            {

                Data.MstItemPrice newItemPrice = new Data.MstItemPrice();

                newItemPrice.ItemId = itemPrice.ItemId;
                newItemPrice.PriceDescription = itemPrice.PriceDescription;
                newItemPrice.Price = itemPrice.Price;
                newItemPrice.TriggerQuantity = itemPrice.TriggerQuantity;

                db.MstItemPrices.InsertOnSubmit(newItemPrice);
                db.SubmitChanges();

                return newItemPrice.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Item Price
        // ==============
        [Route("api/itemPrice/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItemPrice itemPrice)
        {
            try
            {

                var itemPriceId = Convert.ToInt32(id);
                var itemPrices = from d in db.MstItemPrices where d.Id == itemPriceId select d;

                if (itemPrices.Any())
                {
                    var updateitemPrice = itemPrices.FirstOrDefault();

                    updateitemPrice.ItemId = itemPrice.ItemId;
                    updateitemPrice.PriceDescription = itemPrice.PriceDescription;
                    updateitemPrice.Price = itemPrice.Price;
                    updateitemPrice.TriggerQuantity = itemPrice.TriggerQuantity;

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
        // DELETE Item Price
        // ==============
        [Route("api/itemPrice/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemPriceId = Convert.ToInt32(id);
                var itemPrices = from d in db.MstItemPrices where d.Id == itemPriceId select d;

                if (itemPrices.Any())
                {
                    db.MstItemPrices.DeleteOnSubmit(itemPrices.First());
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