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

        // ===========
        // LIST Journal
        // ===========
        [Route("api/journal/list")]
        public List<Models.TrnJournal> Get()
        {
            var Term = from d in db.TrnJournals
                       select new Models.TrnJournal
                       {
                           Id = d.Id,
                           
                       };
            return Term.ToList();
        }

        // ===========
        // ADD Journal
        // ===========
        [Route("api/journal/add")]
        public int Post(Models.TrnJournal term)
        {
            try
            {

                Data.TrnJournal newTerm = new Data.TrnJournal();

                //
               
                //

                db.TrnJournals.InsertOnSubmit(newTerm);
                db.SubmitChanges();

                return newTerm.Id;
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
        public HttpResponseMessage Put(String id, Models.TrnJournal term)
        {
            try
            {

                var TermId = Convert.ToInt32(id);
                var Term = from d in db.TrnJournals where d.Id == TermId select d;

                if (Term.Any())
                {
                    var updateTax = Term.FirstOrDefault();

                    //
                    
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
                var TaxId = Convert.ToInt32(id);
                var Tax = from d in db.TrnJournals where d.Id == TaxId select d;

                if (Tax.Any())
                {
                    db.TrnJournals.DeleteOnSubmit(Tax.First());
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