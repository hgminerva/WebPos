using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiStockCountController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST StockCount
        // ===========
        [Route("api/stockCount/list")]
        public List<Models.TrnStockCount> Get()
        {
            var stockCount = from d in db.TrnStockCounts
                            select new Models.TrnStockCount
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                StockCountDate = Convert.ToString(d.StockCountDate),
                                StockCountNumber = d.StockCountNumber,
                                Remarks = d.Remarks,
                                PreparedBy = d.PreparedBy,
                                CheckedBy = d.CheckedBy,
                                ApprovedBy = d.ApprovedBy,
                                IsLocked = ((d.IsLocked == 1)? true : false),
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = Convert.ToString(d.EntryDateTime),
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = Convert.ToString(d.UpdateDateTime)

                            };
            return stockCount.ToList();
        }

        // ===========
        // ADD StockCount
        // ===========
        [Route("api/stockCount/add")]
        public int Post(Models.TrnStockCount stockCount)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnStockCount newStockCount = new Data.TrnStockCount();

                newStockCount.PeriodId = stockCount.PeriodId;
                newStockCount.StockCountDate = Convert.ToDateTime(stockCount.StockCountDate);
                newStockCount.StockCountNumber = stockCount.StockCountNumber;
                newStockCount.Remarks = stockCount.Remarks;
                newStockCount.PreparedBy = stockCount.PreparedBy;
                newStockCount.CheckedBy = stockCount.CheckedBy;
                newStockCount.ApprovedBy = stockCount.ApprovedBy;
                newStockCount.IsLocked = isLocked;
                newStockCount.EntryUserId = mstUserId;
                newStockCount.EntryDateTime = date;
                newStockCount.UpdateUserId = mstUserId;
                newStockCount.UpdateDateTime = date;

                db.TrnStockCounts.InsertOnSubmit(newStockCount);
                db.SubmitChanges();

                return newStockCount.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE StockCount
        // ==============
        [Route("api/stockCount/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnStockCount stockCount)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var stockCountId = Convert.ToInt32(id);
                var stockCounts = from d in db.TrnStockCounts where d.Id == stockCountId select d;

                if (stockCounts.Any())
                {
                    var updateStockCount = stockCounts.FirstOrDefault();

                    updateStockCount.PeriodId = stockCount.PeriodId;
                    updateStockCount.StockCountDate = Convert.ToDateTime(stockCount.StockCountDate);
                    updateStockCount.StockCountNumber = stockCount.StockCountNumber;
                    updateStockCount.Remarks = stockCount.Remarks;
                    updateStockCount.PreparedBy = stockCount.PreparedBy;
                    updateStockCount.CheckedBy = stockCount.CheckedBy;
                    updateStockCount.ApprovedBy = stockCount.ApprovedBy;                
                    updateStockCount.IsLocked = isLocked;
                    updateStockCount.UpdateUserId = mstUserId;
                    updateStockCount.UpdateDateTime = date;

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
        // DELETE StockCount
        // ==============
        [Route("api/stockCount/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var stockCountId = Convert.ToInt32(id);
                var stockCounts = from d in db.TrnStockCounts where d.Id == stockCountId select d;

                if (stockCounts.Any())
                {
                    db.TrnStockCounts.DeleteOnSubmit(stockCounts.First());
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