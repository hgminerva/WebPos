using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiPayTypeController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Pay Type
        // ===========
        [Route("api/payType/list")]
        public List<Models.MstPayType> Get()
        {
            var payTypes = from d in db.MstPayTypes
                           select new Models.MstPayType
                           {
                               Id = d.Id,
                               PayType = d.PayType,
                               AccountId = Convert.ToInt32(d.AccountId)
                           };
            return payTypes.ToList();
        }
        // ===========
        // ADD Pay Type
        // ===========
        [Route("api/payType/add")]
        public int Post(Models.MstPayType payType)
        {
            try
            {
                Data.MstPayType newPayType = new Data.MstPayType();

                newPayType.Id = payType.Id;
                newPayType.PayType = payType.PayType;
                newPayType.AccountId = payType.AccountId;

                db.MstPayTypes.InsertOnSubmit(newPayType);
                db.SubmitChanges();

                return  newPayType.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Pay Type
        // ==============
        [Route("api/payType/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstPayType payType)
        {
            try
            {
                var isLocked = true;

                var payTypeId = Convert.ToInt32(id);
                var payTypes = from d in db.MstPayTypes where d.Id == payTypeId select d;

                if (payTypes.Any())
                {
                    var updatePayType = payTypes.FirstOrDefault();

                    updatePayType.Id = payType.Id;
                    updatePayType.PayType = payType.PayType;
                    updatePayType.AccountId = payType.AccountId;

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
        // DELETE Pay Type
        // ==============
        [Route("api/payType/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var payTypeId = Convert.ToInt32(id);
                var payTypes = from d in db.MstPayTypes where d.Id == payTypeId select d;

                if (payTypes.Any())
                {
                    db.MstPayTypes.DeleteOnSubmit(payTypes.First());
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