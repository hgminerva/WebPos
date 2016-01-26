using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiStockInController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST stockIn
        // ===========
        [Route("api/stockIn/list")]
        public List<Models.TrnStockIn> Get()
        {
            var stockIn = from d in db.TrnStockIns
                             select new Models.TrnStockIn
                             {
                                 Id = d.Id,
                                 PeriodId = d.PeriodId,
                                 StockInDate = d.StockInDate,
                                 StockInNumber = d.StockInNumber,
                                 SupplierId = d.SupplierId,
                                 Remarks = d.Remarks,
                                 IsReturn = d.IsReturn,
                                 PreparedBy = d.PreparedBy,
                                 CheckedBy = d.CheckedBy,
                                 ApprovedBy = d.ApprovedBy,
                                 IsLocked = ((d.IsLocked == 1) ? true : false),
                                 EntryUserId = d.EntryUserId,
                                 EntryDateTime = Convert.ToString(d.EntryDateTime),
                                 UpdateUserId = d.UpdateUserId,
                                 UpdateDateTime = Convert.ToString(d.UpdateDateTime)

                             };
            return stockIn.ToList();
        }

        // ===========
        // ADD stockIn
        // ===========
        [Route("api/stockIn/add")]
        public int Post(Models.TrnStockIn stockIn)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnStockIn newstockIn = new Data.TrnStockIn();

                newstockIn.PeriodId = stockIn.PeriodId;
                newstockIn.StockInDate = Convert.ToDateTime(stockIn.StockInDate);
                newstockIn.StockInNumber = stockIn.StockInNumber;
                newstockIn.Remarks = stockIn.Remarks;
                newstockIn.IsReturn = stockIn.IsReturn;
                newstockIn.CollectionId = stockIn.CollectionId;
                newstockIn.PurchaseOrderId = stockIn.PurchaseOrderId;
                newstockIn.PreparedBy = stockIn.PreparedBy;
                newstockIn.CheckedBy = stockIn.CheckedBy;
                newstockIn.ApprovedBy = stockIn.ApprovedBy;
                newstockIn.IsLocked = isLocked;
                newstockIn.EntryUserId = mstUserId;
                newstockIn.EntryDateTime = date;
                newstockIn.UpdateUserId = mstUserId;
                newstockIn.UpdateDateTime = date;

                db.TrnStockIns.InsertOnSubmit(newstockIn);
                db.SubmitChanges();

                return newstockIn.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE stockIn
        // ==============
        [Route("api/stockIn/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnStockIn stockIn)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var stockInId = Convert.ToInt32(id);
                var stockIns = from d in db.TrnStockIns where d.Id == stockInId select d;

                if (stockIns.Any())
                {
                    var updatestockIn = stockIns.FirstOrDefault();

                    updatestockIn.PeriodId = stockIn.PeriodId;
                    updatestockIn.StockInDate = Convert.ToDateTime(stockIn.StockInDate);
                    updatestockIn.StockInNumber = stockIn.StockInNumber;
                    updatestockIn.Remarks = stockIn.Remarks;
                    updatestockIn.IsReturn = stockIn.IsReturn;
                    updatestockIn.CollectionId = stockIn.CollectionId;
                    updatestockIn.PurchaseOrderId = stockIn.PurchaseOrderId;
                    updatestockIn.PreparedBy = stockIn.PreparedBy;
                    updatestockIn.CheckedBy = stockIn.CheckedBy;
                    updatestockIn.ApprovedBy = stockIn.ApprovedBy;
                    updatestockIn.IsLocked = isLocked;
                    updatestockIn.UpdateUserId = mstUserId;
                    updatestockIn.UpdateDateTime = date;

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
        // DELETE stockIn
        // ==============
        [Route("api/stockIn/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var stockInId = Convert.ToInt32(id);
                var stockIns = from d in db.TrnStockIns where d.Id == stockInId select d;

                if (stockIns.Any())
                {
                    db.TrnStockIns.DeleteOnSubmit(stockIns.First());
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