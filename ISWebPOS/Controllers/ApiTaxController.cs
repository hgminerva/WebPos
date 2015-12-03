using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiTaxController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Tax
        // ===========
        [Route("api/tax/list")]
        public List<Models.MstTax> Get()
        {
            var Tax = from d in db.MstTaxes
                      select new Models.MstTax
                      {
                          Id = d.Id,
                          Code = d.Code,
                          Tax = d.Tax,
                          Rate = d.Rate,
                          AccountId = d.AccountId
                      };
            return Tax.ToList();
        }

        // ===========
        // ADD Tax
        // ===========
        [Route("api/tax/add")]
        public int Post(Models.MstTax tax)
        {
            try
            {

                Data.MstTax newTax = new Data.MstTax();

                //
                newTax.Code = tax.Code;
                newTax.Tax = tax.Tax;
                newTax.Rate = tax.Rate;
                newTax.AccountId = tax.AccountId;
                //

                db.MstTaxes.InsertOnSubmit(newTax);
                db.SubmitChanges();

                return newTax.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Tax
        // ==============
        [Route("api/tax/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstTax tax)
        {
            try
            {

                var TaxId = Convert.ToInt32(id);
                var Tax = from d in db.MstTaxes where d.Id == TaxId select d;

                if (Tax.Any())
                {
                    var updateTax = Tax.FirstOrDefault();

                    //
                    updateTax.Code = tax.Code;
                    updateTax.Tax = tax.Tax;
                    updateTax.Rate = tax.Rate;
                    updateTax.AccountId = tax.AccountId;
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
        // DELETE Tax
        // ==============
        [Route("api/tax/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var TaxId = Convert.ToInt32(id);
                var Tax = from d in db.MstTaxes where d.Id == TaxId select d;

                if (Tax.Any())
                {
                    db.MstTaxes.DeleteOnSubmit(Tax.First());
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