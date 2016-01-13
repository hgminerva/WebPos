using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiJournalController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ============
        // LIST Journal
        // ============
        [Route("api/journal/list")]
        public List<Models.TrnJournal> Get()
        {
            var Journal = from d in db.TrnJournals
                       select new Models.TrnJournal
                       {
                           Id = d.Id,
                           JournalDate = Convert.ToString(d.JournalDate),
                           JournalRefDocument = d.JournalRefDocument,
                           AccountId = d.AccountId,
                           DebitAmount = d.DebitAmount,
                           CreditAmount = d.CreditAmount,
                           SalesId = d.SalesId,
                           StockInId = d.StockInId,
                           StockOutId = d.StockOutId,
                           CollectionId = d.CollectionId,
                           DCMemoId = d.DCMemoId,
                           DisbursementId = d.DisbursementId
                       };
            return Journal.ToList();
        }

        // ===========
        // ADD Journal
        // ===========
        [Route("api/journal/add")]
        public int Post(Models.TrnJournal journal)
        {
            try
            {

                Data.TrnJournal newJournal = new Data.TrnJournal();

                //
                newJournal.JournalDate = Convert.ToDateTime(journal.JournalDate);
                newJournal.JournalRefDocument = journal.JournalRefDocument;
                newJournal.AccountId = journal.AccountId;
                newJournal.DebitAmount = journal.DebitAmount;
                newJournal.CreditAmount = journal.CreditAmount;
                newJournal.SalesId = journal.SalesId;
                newJournal.StockInId = journal.StockInId;
                newJournal.StockOutId = journal.StockOutId;
                newJournal.CollectionId = journal.CollectionId;
                newJournal.DCMemoId = journal.DCMemoId;
                newJournal.DisbursementId = journal.DisbursementId;
                //

                db.TrnJournals.InsertOnSubmit(newJournal);
                db.SubmitChanges();

                return newJournal.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Journal
        // ==============
        [Route("api/journal/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnJournal journal)
        {
            try
            {

                var JournalId = Convert.ToInt32(id);
                var Journal = from d in db.TrnJournals where d.Id == JournalId select d;

                if (Journal.Any())
                {
                    var updateJournal = Journal.FirstOrDefault();

                    //
                    updateJournal.JournalDate = Convert.ToDateTime(journal.JournalDate);
                    updateJournal.JournalRefDocument = journal.JournalRefDocument;
                    updateJournal.AccountId = journal.AccountId;
                    updateJournal.DebitAmount = journal.DebitAmount;
                    updateJournal.CreditAmount = journal.CreditAmount;
                    updateJournal.SalesId = journal.SalesId;
                    updateJournal.StockInId = journal.StockInId;
                    updateJournal.StockOutId = journal.StockOutId;
                    updateJournal.CollectionId = journal.CollectionId;
                    updateJournal.DCMemoId = journal.DCMemoId;
                    updateJournal.DisbursementId = journal.DisbursementId;                              
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
        // DELETE Journal
        // ==============
        [Route("api/journal/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var JournalId = Convert.ToInt32(id);
                var Journal = from d in db.TrnJournals where d.Id == JournalId select d;

                if (Journal.Any())
                {
                    db.TrnJournals.DeleteOnSubmit(Journal.First());
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