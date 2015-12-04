using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiAuditTrailController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST AuditTrail
        // ===========
        [Route("api/audittrail/list")]
        public List<Models.SysAuditTrail> Get()
        {
            var AuditTrail = from d in db.SysAuditTrails
                       select new Models.SysAuditTrail
                       {
                           Id = d.Id,
                           UserId = d.UserId,
                           AuditDate = Convert.ToString(d.AuditDate),
                           TableInformation = d.TableInformation,
                           RecordInformation = d.RecordInformation,
                           FormInformation = d.FormInformation,
                           ActionInformation = d.ActionInformation
                       };
            return AuditTrail.ToList();
        }

        // ===========
        // ADD AuditTrail
        // ===========
        [Route("api/audittrail/add")]
        public int Post(Models.SysAuditTrail audittrail)
        {
            try
            {
                Data.SysAuditTrail newAuditTrail = new Data.SysAuditTrail();

                //
                newAuditTrail.UserId = audittrail.UserId;
                newAuditTrail.AuditDate = Convert.ToDateTime(audittrail.AuditDate);
                newAuditTrail.TableInformation = audittrail.TableInformation;
                newAuditTrail.RecordInformation = audittrail.RecordInformation;
                newAuditTrail.FormInformation = audittrail.FormInformation;
                newAuditTrail.ActionInformation = audittrail.ActionInformation;
                //

                db.SysAuditTrails.InsertOnSubmit(newAuditTrail);
                db.SubmitChanges();

                return newAuditTrail.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE AuditTrail
        // ==============
        [Route("api/audittrail/update/{id}")]
        public HttpResponseMessage Put(String id, Models.SysAuditTrail audittrail)
        {
            try
            {

                var AuditTrailId = Convert.ToInt32(id);
                var AuditTrail = from d in db.SysAuditTrails where d.Id == AuditTrailId select d;

                if (AuditTrail.Any())
                {
                    var updateAuditTrail = AuditTrail.FirstOrDefault();

                    //
                    updateAuditTrail.UserId = audittrail.UserId;
                    updateAuditTrail.AuditDate = Convert.ToDateTime(audittrail.AuditDate);
                    updateAuditTrail.TableInformation = audittrail.TableInformation;
                    updateAuditTrail.RecordInformation = audittrail.RecordInformation;
                    updateAuditTrail.FormInformation = audittrail.FormInformation;
                    updateAuditTrail.ActionInformation = audittrail.ActionInformation;
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
        // DELETE AuditTrail
        // ==============
        [Route("api/audittrail/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var AuditTrailId = Convert.ToInt32(id);
                var AuditTrail = from d in db.SysAuditTrails where d.Id == AuditTrailId select d;

                if (AuditTrail.Any())
                {
                    db.SysAuditTrails.DeleteOnSubmit(AuditTrail.First());
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