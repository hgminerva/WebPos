using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiPurchaseOrderLineController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ======================
        // LIST PurchaseOrderLine
        // ======================
        [Route("api/purchaseOrderLine/list")]
        public List<Models.TrnPurchaseOrderLine> Get()
        {
            var PurchaseOrderLine = from d in db.TrnPurchaseOrderLines
                       select new Models.TrnPurchaseOrderLine
                       {
                           Id = d.Id,
                           PurchaseOrderId = d.PurchaseOrderId,
                           ItemId = d.ItemId,
                           UnitId = d.UnitId,
                           Quantity = d.Quantity,
                           Cost = d.Cost,
                           Amount = d.Amount
                       };
            return PurchaseOrderLine.ToList();
        }

        // =====================
        // ADD PurchaseOrderLine
        // =====================
        [Route("api/purchaseOrderLine/add")]
        public int Post(Models.TrnPurchaseOrderLine purchaseorderline)
        {
            try
            {

                Data.TrnPurchaseOrderLine newPurchaseOrderLine = new Data.TrnPurchaseOrderLine();

                //
                newPurchaseOrderLine.PurchaseOrderId = purchaseorderline.PurchaseOrderId;
                newPurchaseOrderLine.ItemId = purchaseorderline.ItemId;
                newPurchaseOrderLine.UnitId = purchaseorderline.UnitId;
                newPurchaseOrderLine.Quantity = purchaseorderline.Quantity;
                newPurchaseOrderLine.Cost = purchaseorderline.Cost;
                newPurchaseOrderLine.Amount = purchaseorderline.Amount;
                //

                db.TrnPurchaseOrderLines.InsertOnSubmit(newPurchaseOrderLine);
                db.SubmitChanges();

                return newPurchaseOrderLine.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ========================
        // UPDATE PurchaseOrderLine
        // ========================
        [Route("api/purchaseOrderLine/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnPurchaseOrderLine purchaseorderline)
        {
            try
            {

                var PurchaseOrderLineId = Convert.ToInt32(id);
                var PurchaseOrderLine = from d in db.TrnPurchaseOrderLines where d.Id == PurchaseOrderLineId select d;

                if (PurchaseOrderLine.Any())
                {
                    var updatePurchaseOrderLine = PurchaseOrderLine.FirstOrDefault();

                    //
                    updatePurchaseOrderLine.PurchaseOrderId = purchaseorderline.PurchaseOrderId;
                    updatePurchaseOrderLine.ItemId = purchaseorderline.ItemId;
                    updatePurchaseOrderLine.UnitId = purchaseorderline.UnitId;
                    updatePurchaseOrderLine.Quantity = purchaseorderline.Quantity;
                    updatePurchaseOrderLine.Cost = purchaseorderline.Cost;
                    updatePurchaseOrderLine.Amount = purchaseorderline.Amount;
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

        // ========================
        // DELETE purchaseorderline
        // ========================
        [Route("api/purchaseOrderLine/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var PurchaseOrderLineId = Convert.ToInt32(id);
                var PurchaseOrderLine = from d in db.TrnPurchaseOrderLines where d.Id == PurchaseOrderLineId select d;

                if (PurchaseOrderLine.Any())
                {
                    db.TrnPurchaseOrderLines.DeleteOnSubmit(PurchaseOrderLine.First());
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