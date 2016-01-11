using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemInventoryController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ==================
        // LIST ItemInventory
        // ==================
        [Route("api/itemInventory/list")]
        public List<Models.MstItemInventory> Get()
        {
            var itemInventory = from d in db.MstItemInventories
                                select new Models.MstItemInventory
                                {
                                    Id = d.Id,
                                    ItemId = d.ItemId,
                                    InventoryDate = Convert.ToString(d.InventoryDate),
                                    Quantity = d.Quantity
                                };
            return itemInventory.ToList();
        }

        // =================
        // ADD ItemInventory
        // =================
        [Route("api/itemInventory/add")]
        public int Post(Models.MstItemInventory iteminventory)
        {
            try
            {
                var date = DateTime.Now;

                Data.MstItemInventory newItemInventory = new Data.MstItemInventory();

                //
                newItemInventory.ItemId = iteminventory.ItemId;
                newItemInventory.InventoryDate = Convert.ToDateTime(iteminventory.InventoryDate);
                newItemInventory.Quantity = iteminventory.Quantity;
                //

                db.MstItemInventories.InsertOnSubmit(newItemInventory);
                db.SubmitChanges();

                return newItemInventory.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ====================
        // UPDATE ItemInventory
        // ====================
        [Route("api/itemInventory/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItemInventory iteminventory)
        {
            try
            {

                var date = DateTime.Now;
                var itemInventoryId = Convert.ToInt32(id);
                var itemInventory = from d in db.MstItemInventories where d.Id == itemInventoryId select d;

                if (itemInventory.Any())
                {
                    var updateItemInventory = itemInventory.FirstOrDefault();

                    //
                    updateItemInventory.ItemId = iteminventory.ItemId;
                    updateItemInventory.InventoryDate = Convert.ToDateTime(iteminventory.InventoryDate);
                    updateItemInventory.Quantity = iteminventory.Quantity;
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
        // DELETE ItemInventory
        // ====================
        [Route("api/itemInventory/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemInventoryId = Convert.ToInt32(id);
                var itemInventory = from d in db.MstItemInventories where d.Id == itemInventoryId select d;

                if (itemInventory.Any())
                {
                    db.MstItemInventories.DeleteOnSubmit(itemInventory.First());
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