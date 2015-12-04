using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
namespace ISWebPOS.Controllers
{
    public class ApiSalesLockedController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST SalesLocked
        // ===========
        [Route("api/saleslocked/list")]
        public List<Models.SysSalesLocked> Get()
        {
            var isLocked = true;
            var SalesLocked = from d in db.SysSalesLockeds
                             select new Models.SysSalesLocked
                             {
                                 Id = d.Id,
                                 SalesId = d.SalesId,
                                 UserId = d.UserId
                             };
            return SalesLocked.ToList();
        }

        // ===========
        // ADD SalesLocked
        // ===========
        [Route("api/saleslocked/add")]
        public int Post(Models.SysSalesLocked saleslocked)
        {
            try
            {
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();

                Data.SysSalesLocked newSalesLocked = new Data.SysSalesLocked();

                //
                newSalesLocked.SalesId = saleslocked.SalesId;
                newSalesLocked.UserId = mstUserId;
                //

                db.SysSalesLockeds.InsertOnSubmit(newSalesLocked);
                db.SubmitChanges();

                return newSalesLocked.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE SalesLocked
        // ==============
        [Route("api/saleslocked/update/{id}")]
        public HttpResponseMessage Put(String id, Models.SysSalesLocked saleslocked)
        {
            try
            {
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();

                var SalesLockedId = Convert.ToInt32(id);
                var SalesLocked = from d in db.SysSalesLockeds where d.Id == SalesLockedId select d;

                if (SalesLocked.Any())
                {
                    var updateSalesLocked = SalesLocked.FirstOrDefault();

                    //
                    updateSalesLocked.SalesId = saleslocked.SalesId;
                    updateSalesLocked.UserId = mstUserId;
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
        // DELETE SalesLocked
        // ==============
        [Route("api/saleslocked/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var SalesLockedId = Convert.ToInt32(id);
                var SalesLocked = from d in db.SysSalesLockeds where d.Id == SalesLockedId select d;

                if (SalesLocked.Any())
                {
                    db.SysSalesLockeds.DeleteOnSubmit(SalesLocked.First());
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