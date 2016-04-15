using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiStockInLineController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST StockInLine
        // ===========
        [Route("api/stockInLine/list")]
        public List<Models.TrnStockInLine> get()
        {
            return null;
        }

        // ===========
        // ADD StockInLine
        // ===========
        [Route("api/stockInLine/add")]
        public int post(Models.TrnStockInLine stockInLine)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnStockInLine newstockIn = new Data.TrnStockInLine();

               

                db.TrnStockInLines.InsertOnSubmit(newstockIn);
                db.SubmitChanges();

                return newstockIn.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE StockInLine
        // ==============
        [Route("api/stockInLine/update/{id}")]
        public HttpResponseMessage put(int id, Models.TrnStockInLine stockInLine)
        {
            try
            {
                var isLocked = 1;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var stockInLineId = Convert.ToInt32(id);
                var stockInLines = from d in db.TrnStockInLines where d.Id == stockInLineId select d;

                if (stockInLines.Any())
                {
                   

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
        // DELETE StockInLine
        // ==============
        [Route("api/stockInLine/delete/{id}")]
        public HttpResponseMessage delete(String id)
        {
            try
            {
                var stockInLineId = Convert.ToInt32(id);
                var stockInLines = from d in db.TrnStockInLines where d.Id == stockInLineId select d;

                if (stockInLines.Any())
                {
                    db.TrnStockInLines.DeleteOnSubmit(stockInLines.First());
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