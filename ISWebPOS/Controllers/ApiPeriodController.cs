using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiPeriodController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Period
        // ===========
        [Route("api/period/list")]
        public List<Models.MstPeriod> Get()
        {
            var periods = from d in db.MstPeriods
                           select new Models.MstPeriod
                           {
                               Id = d.Id,
                               Period = d.Period
                           };
            return periods.ToList();
        }
        // ===========
        // ADD Period
        // ===========
        [Route("api/period/add")]
        public int Post(Models.MstPeriod period)
        {
            try
            {
                Data.MstPeriod newPeriod = new Data.MstPeriod();

                newPeriod.Id = period.Id;
                newPeriod.Period = period.Period;
                

                db.MstPeriods.InsertOnSubmit(newPeriod);
                db.SubmitChanges();

                return newPeriod.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Period
        // ==============
        [Route("api/period/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstPeriod period)
        {
            try
            {

                var periodId = Convert.ToInt32(id);
                var periods = from d in db.MstPeriods where d.Id == periodId select d;

                if (periods.Any())
                {
                    var updatePeriod = periods.FirstOrDefault();

                    updatePeriod.Id = period.Id;
                    updatePeriod.Period = period.Period;

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
        // DELETE Account
        // ==============
        [Route("api/period/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var periodId = Convert.ToInt32(id);
                var periods = from d in db.MstPeriods where d.Id == periodId select d;

                if (periods.Any())
                {
                    db.MstPeriods.DeleteOnSubmit(periods.First());
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