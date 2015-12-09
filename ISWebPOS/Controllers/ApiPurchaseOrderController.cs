using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiPurchaseOrderController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST PurchaseOrderLine
        // ===========
        [Route("api/purchaseorder/list")]
        public List<Models.TrnPurchaseOrder> Get()
        {
            var isLocked = true;
            var PurchaseOrder = from d in db.TrnPurchaseOrders
                                    select new Models.TrnPurchaseOrder
                                    {                                        
                                        Id = d.Id,
                                        PeriodId = d.PeriodId,
                                        PurchaseOrderDate = Convert.ToString(d.PurchaseOrderDate),
                                        PurchaseOrderNumber = d.PurchaseOrderNumber,
                                        Amount = d.Amount,
                                        SupplierId = d.SupplierId,
                                        Remarks = d.Remarks,
                                        PreparedBy = d.PreparedBy,
                                        CheckedBy = d.CheckedBy,
                                        ApprovedBy = d.ApprovedBy,
                                        EntryUserId = d.EntryUserId,
                                        EntryDateTime = Convert.ToString(d.EntryDateTime),
                                        UpdateUserId = d.UpdateUserId,
                                        UpdateDateTime = Convert.ToString(d.UpdateDateTime),
                                        IsLocked = isLocked
                                    };
            return PurchaseOrder.ToList();
        }

        // ===========
        // ADD PurchaseOrder
        // ===========
        [Route("api/purchaseorder/add")]
        public int Post(Models.TrnPurchaseOrder purchaseorder)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnPurchaseOrder newPurchaseOrder = new Data.TrnPurchaseOrder();

                //
                newPurchaseOrder.PeriodId = purchaseorder.PeriodId;
                newPurchaseOrder.PurchaseOrderDate = Convert.ToDateTime(purchaseorder.PurchaseOrderDate);
                newPurchaseOrder.PurchaseOrderNumber = purchaseorder.PurchaseOrderNumber;
                newPurchaseOrder.Amount = purchaseorder.Amount;
                newPurchaseOrder.SupplierId = purchaseorder.SupplierId;
                newPurchaseOrder.Remarks = purchaseorder.Remarks;
                newPurchaseOrder.PreparedBy = purchaseorder.PreparedBy;
                newPurchaseOrder.CheckedBy = purchaseorder.CheckedBy;
                newPurchaseOrder.ApprovedBy = purchaseorder.ApprovedBy;
                newPurchaseOrder.IsLocked = isLocked;
                newPurchaseOrder.EntryUserId = mstUserId;
                newPurchaseOrder.EntryDateTime = date;
                newPurchaseOrder.UpdateUserId = mstUserId;
                newPurchaseOrder.UpdateDateTime = date;
                //

                db.TrnPurchaseOrders.InsertOnSubmit(newPurchaseOrder);
                db.SubmitChanges();

                return newPurchaseOrder.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE PurchaseOrder
        // ==============
        [Route("api/purchaseorder/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnPurchaseOrder purchaseorder)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var PurchaseOrderId = Convert.ToInt32(id);
                var PurchaseOrder = from d in db.TrnPurchaseOrders where d.Id == PurchaseOrderId select d;

                if (PurchaseOrder.Any())
                {
                    var updatePurchaseOrder = PurchaseOrder.FirstOrDefault();

                    //
                    updatePurchaseOrder.PeriodId = purchaseorder.PeriodId;
                    updatePurchaseOrder.PurchaseOrderDate = Convert.ToDateTime(purchaseorder.PurchaseOrderDate);
                    updatePurchaseOrder.PurchaseOrderNumber = purchaseorder.PurchaseOrderNumber;
                    updatePurchaseOrder.Amount = purchaseorder.Amount;
                    updatePurchaseOrder.SupplierId = purchaseorder.SupplierId;
                    updatePurchaseOrder.Remarks = purchaseorder.Remarks;
                    updatePurchaseOrder.PreparedBy = purchaseorder.PreparedBy;
                    updatePurchaseOrder.CheckedBy = purchaseorder.CheckedBy;
                    updatePurchaseOrder.ApprovedBy = purchaseorder.ApprovedBy;
                    updatePurchaseOrder.IsLocked = isLocked;
                    updatePurchaseOrder.UpdateUserId = mstUserId;
                    updatePurchaseOrder.UpdateDateTime = date;
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

        // ==============
        // DELETE purchaseorderline
        // ==============
        [Route("api/purchaseorder/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var PurchaseOrderId = Convert.ToInt32(id);
                var PurchaseOrder = from d in db.TrnPurchaseOrders where d.Id == PurchaseOrderId select d;

                if (PurchaseOrder.Any())
                {
                    db.TrnPurchaseOrders.DeleteOnSubmit(PurchaseOrder.First());
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