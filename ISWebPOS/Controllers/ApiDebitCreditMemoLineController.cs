using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiDebitCreditMemoLineController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST DebitCreditMemoLine
        // ===========
        [Route("api/debitcreditmemoline/list")]
        public List<Models.TrnDebitCreditMemoLine> Get()
        {
            var DebitCreditMemoLine = from d in db.TrnDebitCreditMemoLines
                          select new Models.TrnDebitCreditMemoLine
                          {
                              Id = d.Id,
                              DCMemoId = d.DCMemoId,
                              SalesId = d.SalesId,
                              AccountId = d.AccountId,
                              Particulars = d.Particulars,
                              DebitAmount = d.DebitAmount,
                              CreditAmount = d.CreditAmount
                          };
            return DebitCreditMemoLine.ToList();
        }

        // ===========
        // ADD DebitCreditMemoLine
        // ===========
        [Route("api/debitcreditmemoline/add")]
        public int Post(Models.TrnDebitCreditMemoLine debitcreditmemoLine)
        {
            try
            {

                Data.TrnDebitCreditMemoLine newDebitCreditMemoLine = new Data.TrnDebitCreditMemoLine();

                //
                newDebitCreditMemoLine.DCMemoId = debitcreditmemoLine.DCMemoId;
                newDebitCreditMemoLine.SalesId = debitcreditmemoLine.SalesId;
                newDebitCreditMemoLine.AccountId = debitcreditmemoLine.AccountId;
                newDebitCreditMemoLine.Particulars = debitcreditmemoLine.Particulars;
                newDebitCreditMemoLine.DebitAmount = debitcreditmemoLine.DebitAmount;
                newDebitCreditMemoLine.CreditAmount = debitcreditmemoLine.CreditAmount;
                //

                db.TrnDebitCreditMemoLines.InsertOnSubmit(newDebitCreditMemoLine);
                db.SubmitChanges();

                return newDebitCreditMemoLine.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE DebitCreditMemoLine
        // ==============
        [Route("api/debitcreditmemoline/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnDebitCreditMemoLine debitcreditmemoLine)
        {
            try
            {

                var DebitCreditMemoLinelId = Convert.ToInt32(id);
                var DebitCreditMemoLine = from d in db.TrnDebitCreditMemoLines where d.Id == DebitCreditMemoLinelId select d;

                if (DebitCreditMemoLine.Any())
                {
                    var updateDebitCreditMemoLine = DebitCreditMemoLine.FirstOrDefault();

                    //
                    updateDebitCreditMemoLine.DCMemoId = debitcreditmemoLine.DCMemoId;
                    updateDebitCreditMemoLine.SalesId = debitcreditmemoLine.SalesId;
                    updateDebitCreditMemoLine.AccountId = debitcreditmemoLine.AccountId;
                    updateDebitCreditMemoLine.Particulars = debitcreditmemoLine.Particulars;
                    updateDebitCreditMemoLine.DebitAmount = debitcreditmemoLine.DebitAmount;
                    updateDebitCreditMemoLine.CreditAmount = debitcreditmemoLine.CreditAmount;
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
        // DELETE DebitCreditMemoLine
        // ==============
        [Route("api/debitcreditmemoline/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var DebitCreditMemoLineId = Convert.ToInt32(id);
                var DebitCreditMemoLine = from d in db.TrnDebitCreditMemoLines where d.Id == DebitCreditMemoLineId select d;

                if (DebitCreditMemoLine.Any())
                {
                    db.TrnDebitCreditMemoLines.DeleteOnSubmit(DebitCreditMemoLine.First());
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