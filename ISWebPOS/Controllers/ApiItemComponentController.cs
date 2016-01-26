using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemComponentController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST ItemComponent
        // ===========
        [Route("api/ItemComponent/list")]
        public List<Models.MstItemComponent> Get()
        {
            var isLocked = true;

            var itemComponent = from d in db.MstItemComponents
                           select new Models.MstItemComponent
                           {
                               ItemId = d.ItemId,
                               ComponentItemId = d.ComponentItemId,
                               UnitId = d.UnitId,
                               Quantity = d.Quantity,
                               Cost = d.Cost,
                               Amount = d.Amount,
                               IsPrinted = d.IsPrinted
                           };
            return itemComponent.ToList();
        }

        // ===========
        // ADD ItemComponent
        // ===========
        [Route("api/ItemComponent/add")]
        public int Post(Models.MstItemComponent itemComponent)
        {
            try
            {
                Data.MstItemComponent newItemComponent = new Data.MstItemComponent();

                newItemComponent.ItemId = itemComponent.ItemId;
                newItemComponent.ComponentItemId = itemComponent.ComponentItemId;
                newItemComponent.UnitId = itemComponent.UnitId;
                newItemComponent.Quantity = itemComponent.Quantity;
                newItemComponent.Cost = itemComponent.Cost;
                newItemComponent.Amount = itemComponent.Amount;
                newItemComponent.IsPrinted = itemComponent.IsPrinted;

                db.MstItemComponents.InsertOnSubmit(newItemComponent);
                db.SubmitChanges();

                return newItemComponent.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE ItemComponent
        // ==============
        [Route("api/ItemComponent/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItemComponent itemComponent)
        {
            try
            {
                var itemComponentId = Convert.ToInt32(id);
                var itemComponents = from d in db.MstItemComponents where d.Id == itemComponentId select d;

                if (itemComponents.Any())
                {
                    var updateItemComponent = itemComponents.FirstOrDefault();

                    updateItemComponent.ItemId = itemComponent.ItemId;
                    updateItemComponent.ComponentItemId = itemComponent.ComponentItemId;
                    updateItemComponent.UnitId = itemComponent.UnitId;
                    updateItemComponent.Quantity = itemComponent.Quantity;
                    updateItemComponent.Cost = itemComponent.Cost;
                    updateItemComponent.Amount = itemComponent.Amount;
                    updateItemComponent.IsPrinted = itemComponent.IsPrinted;

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
        // DELETE ItemComponent
        // ==============
        [Route("api/ItemComponent/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemComponentId = Convert.ToInt32(id);
                var itemComponents = from d in db.MstItemComponents where d.Id == itemComponentId select d;

                if (itemComponents.Any())
                {
                    db.MstItemComponents.DeleteOnSubmit(itemComponents.First());
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
