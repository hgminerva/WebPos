using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemGroupItemController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ==================
        // LIST ItemGroupItem
        // ==================
        [Route("api/itemGroupItem/list")]
        public List<Models.MstItemGroupItem> Get()
        {
            var itemGroupItem = from d in db.MstItemGroupItems
                            select new Models.MstItemGroupItem
                            {
                                Id = d.Id,
                                ItemGroupId = d.ItemGroupId
                            };
            return itemGroupItem.ToList();
        }

        // =================
        // ADD ItemGroupItem
        // =================
        [Route("api/itemGroupItem/add")]
        public int Post(Models.MstItemGroupItem itemgroupitem)
        {
            try
            {

                Data.MstItemGroupItem newItemGroupItem = new Data.MstItemGroupItem();

                //
                newItemGroupItem.ItemGroupId = itemgroupitem.ItemGroupId;
                //

                db.MstItemGroupItems.InsertOnSubmit(newItemGroupItem);
                db.SubmitChanges();

                return newItemGroupItem.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ====================
        // UPDATE ItemGroupItem
        // ====================
        [Route("api/itemGroupItem/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItemGroupItem itemgroupitem)
        {
            try
            {

                var itemGrouptId = Convert.ToInt32(id);
                var itemGroupItem = from d in db.MstItemGroupItems where d.Id == itemGrouptId select d;

                if (itemGroupItem.Any())
                {
                    var updateItemGroup = itemGroupItem.FirstOrDefault();

                    //
                    updateItemGroup.ItemGroupId = itemgroupitem.ItemGroupId;
                    //

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

        // ====================
        // DELETE ItemGroupItem
        // ====================
        [Route("api/itemGroupItem/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemGrouptItemId = Convert.ToInt32(id);
                var itemGroupItem = from d in db.MstItemGroupItems where d.Id == itemGrouptItemId select d;

                if (itemGroupItem.Any())
                {
                    db.MstItemGroupItems.DeleteOnSubmit(itemGroupItem.First());
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