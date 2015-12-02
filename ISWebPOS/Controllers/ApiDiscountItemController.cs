using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiDiscountItemController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST DiscountItem
        // ===========
        [Route("api/discountItem/list")]
        public List<Models.MstDiscountItem> Get()
        {
            var isLocked = true;

            var discountItem = from d in db.MstDiscountItems
                           select new Models.MstDiscountItem
                           {
                               Id = d.Id,
                               DiscountId = d.DiscountId,
                               ItemId = d.ItemId
                           };
            return discountItem.ToList();
        }

        // ===========
        // ADD DiscountItem
        // ===========
        [Route("api/discountItem/add")]
        public int Post(Models.MstDiscountItem discountItem)
        {
            try
            {

                Data.MstDiscountItem newDiscountItem = new Data.MstDiscountItem();

                newDiscountItem.Id = discountItem.Id;
                newDiscountItem.DiscountId = discountItem.DiscountId;
                newDiscountItem.ItemId = discountItem.ItemId;

                db.MstDiscountItems.InsertOnSubmit(newDiscountItem);
                db.SubmitChanges();

                return newDiscountItem.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE DiscountItem
        // ==============
        [Route("api/discountItem/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstDiscountItem discountItem)
        {
            try
            {
                var discountItemId = Convert.ToInt32(id);
                var discountItems = from d in db.MstDiscountItems where d.Id == discountItemId select d;

                if (discountItems.Any())
                {
                    var updateDiscountItem = discountItems.FirstOrDefault();

                    updateDiscountItem.Id = discountItem.Id;
                    updateDiscountItem.DiscountId = discountItem.DiscountId;
                    updateDiscountItem.ItemId = discountItem.ItemId;

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
        // DELETE DiscountItem
        // ==============
        [Route("api/discountItem/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var discountItemId = Convert.ToInt32(id);
                var discountItems = from d in db.MstDiscountItems where d.Id == discountItemId select d;

                if (discountItems.Any())
                {
                    db.MstDiscountItems.DeleteOnSubmit(discountItems.First());
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
