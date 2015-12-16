using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace ISWebPOS.Controllers
{
    public class ApiUnitController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        [Route("api/unit/list")]
        public List<Models.MstUnit> Get()
        {
            var units = from d in db.MstUnits
                           select new Models.MstUnit
                           {
                               Id = d.Id,
                               Unit = d.Unit
                           };
            return units.ToList();
        }

        // ===========
        // ADD Unit
        // ===========
        [Route("api/unit/add")]
        public int Post(Models.MstUnit unit)
        {
            try
            {
                

                Data.MstUnit newUnit = new Data.MstUnit();

                newUnit.Unit = unit.Unit;
                

                db.MstUnits.InsertOnSubmit(newUnit);
                db.SubmitChanges();

                return newUnit.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Unit
        // ==============
        [Route("api/unit/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstUnit unit)
        {
            try
            {

                var unitId = Convert.ToInt32(id);
                var units = from d in db.MstUnits where d.Id == unitId select d;

                if (units.Any())
                {
                    var updateUnit = units.FirstOrDefault();

                    updateUnit.Unit = unit.Unit;

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
        // DELETE Unit
        // ==============
        [Route("api/unit/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var unitId = Convert.ToInt32(id);
                var units = from d in db.MstUnits where d.Id == unitId select d;

                if (units.Any())
                {
                    db.MstUnits.DeleteOnSubmit(units.First());
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