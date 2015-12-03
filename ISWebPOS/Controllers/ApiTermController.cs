using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiTermController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Term
        // ===========
        [Route("api/term/list")]
        public List<Models.MstTerm> Get()
        {
            var Term = from d in db.MstTerms
                       select new Models.MstTerm
                       {
                           Id = d.Id,
                           Term = d.Term,
                           NumberOfDays = d.NumberOfDays
                       };
            return Term.ToList();
        }

        // ===========
        // ADD Term
        // ===========
        [Route("api/term/add")]
        public int Post(Models.MstTerm term)
        {
            try
            {

                Data.MstTerm newTerm = new Data.MstTerm();

                //
                newTerm.Term = term.Term;
                newTerm.NumberOfDays = term.NumberOfDays;
                //

                db.MstTerms.InsertOnSubmit(newTerm);
                db.SubmitChanges();

                return newTerm.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Term
        // ==============
        [Route("api/term/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstTerm term)
        {
            try
            {

                var TermId = Convert.ToInt32(id);
                var Term = from d in db.MstTerms where d.Id == TermId select d;

                if (Term.Any())
                {
                    var updateTax = Term.FirstOrDefault();

                    //
                    updateTax.Term = term.Term;
                    updateTax.NumberOfDays = term.NumberOfDays;
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
        // DELETE Term
        // ==============
        [Route("api/tax/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var TaxId = Convert.ToInt32(id);
                var Tax = from d in db.MstTerms where d.Id == TaxId select d;

                if (Tax.Any())
                {
                    db.MstTerms.DeleteOnSubmit(Tax.First());
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