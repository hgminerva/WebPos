using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiStockOutController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST stockOut
        // ===========
        [Route("api/stockOut/list")]
        public List<Models.TrnStockOut> Get()
        {
            var stockOut = from d in db.TrnStockOuts
                          select new Models.TrnStockOut
                          {
                              Id = d.Id,
                              PeriodId = d.PeriodId,
                              StockOutDate = Convert.ToString(d.StockOutDate),
                              StockOutNumber = d.StockOutNumber, 
                              AccountId = d.AccountId,
                              Remarks = d.Remarks,
                              PreparedBy = d.PreparedBy,
                              CheckedBy = d.CheckedBy,
                              ApprovedBy = d.ApprovedBy,
                              IsLocked = ((d.IsLocked) == Convert.ToBoolean(1) ? true : false),
                              EntryUserId = d.EntryUserId,
                              EntryDateTime = Convert.ToString(d.EntryDateTime),
                              UpdateUserId = d.UpdateUserId,
                              UpdateDateTime = Convert.ToString(d.UpdateDateTime)

                          };
            return stockOut.ToList();
        }

        // ===========
        // ADD stockOut
        // ===========
        [Route("api/stockOut/add")]
        public int Post(Models.TrnStockOut stockOut)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnStockOut newstockOut = new Data.TrnStockOut();

                newstockOut.PeriodId = stockOut.PeriodId;
                newstockOut.StockOutDate = Convert.ToDateTime(stockOut.StockOutDate);
                newstockOut.StockOutNumber = stockOut.StockOutNumber;
                newstockOut.AccountId = stockOut.AccountId;
                newstockOut.Remarks = stockOut.Remarks;
                newstockOut.PreparedBy = stockOut.PreparedBy;
                newstockOut.CheckedBy = stockOut.CheckedBy;
                newstockOut.ApprovedBy = stockOut.ApprovedBy;
                newstockOut.IsLocked = Convert.ToBoolean(isLocked);
                newstockOut.EntryUserId = mstUserId;
                newstockOut.EntryDateTime = date;
                newstockOut.UpdateUserId = mstUserId;
                newstockOut.UpdateDateTime = date;

                db.TrnStockOuts.InsertOnSubmit(newstockOut);
                db.SubmitChanges();

                return newstockOut.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE stockOut
        // ==============
        [Route("api/stockOut/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnStockOut stockOut)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var stockOutId = Convert.ToInt32(id);
                var stockOuts = from d in db.TrnStockOuts where d.Id == stockOutId select d;

                if (stockOuts.Any())
                {
                    var updatestockOut = stockOuts.FirstOrDefault();

                    updatestockOut.PeriodId = stockOut.PeriodId;
                    updatestockOut.StockOutDate = Convert.ToDateTime(stockOut.StockOutDate);
                    updatestockOut.StockOutNumber = stockOut.StockOutNumber;
                    updatestockOut.AccountId = stockOut.AccountId;
                    updatestockOut.Remarks = stockOut.Remarks;
                    updatestockOut.PreparedBy = stockOut.PreparedBy;
                    updatestockOut.CheckedBy = stockOut.CheckedBy;
                    updatestockOut.ApprovedBy = stockOut.ApprovedBy;
                    updatestockOut.IsLocked =  Convert.ToBoolean(isLocked);
                    updatestockOut.UpdateUserId = mstUserId;
                    updatestockOut.UpdateDateTime = date;

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
        // DELETE stockOut
        // ==============
        [Route("api/stockOut/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var stockOutId = Convert.ToInt32(id);
                var stockOuts = from d in db.TrnStockOuts where d.Id == stockOutId select d;

                if (stockOuts.Any())
                {
                    db.TrnStockOuts.DeleteOnSubmit(stockOuts.First());
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