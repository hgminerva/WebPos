using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiTerminalController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Terminal
        // ===========
        [Route("api/terminal/list")]
        public List<Models.MstTerminal> Get()
        {
            var terminals = from d in db.MstTerminals
                           select new Models.MstTerminal
                           {
                               Id = d.Id,
                               Terminal = d.Terminal
                           };
            return terminals.ToList();
        }

        // ===========
        // ADD Terminal
        // ===========
        [Route("api/terminal/add")]
        public int Post(Models.MstTerminal terminal)
        {
            try
            {
                

                Data.MstTerminal newTerminal = new Data.MstTerminal();

                newTerminal.Terminal = terminal.Terminal;
                

                db.MstTerminals.InsertOnSubmit(newTerminal);
                db.SubmitChanges();

                return newTerminal.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Terminal
        // ==============
        [Route("api/terminal/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstTerminal terminal)
        {
            try
            {

                var terminalId = Convert.ToInt32(id);
                var terminals = from d in db.MstTerminals where d.Id == terminalId select d;

                if (terminals.Any())
                {
                    var updateTerminal = terminals.FirstOrDefault();

                    updateTerminal.Terminal = terminal.Terminal;

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
        // DELETE Terminal
        // ==============
        [Route("api/terminal/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var terminalId = Convert.ToInt32(id);
                var terminals = from d in db.MstTerminals where d.Id == terminalId select d;

                if (terminals.Any())
                {
                    db.MstTerminals.DeleteOnSubmit(terminals.First());
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