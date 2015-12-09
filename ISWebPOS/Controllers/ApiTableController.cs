using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiTableController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Table
        // ===========
        [Route("api/table/list")]
        public List<Models.MstTable> Get()
        {
            var Table = from d in db.MstTables
                        select new Models.MstTable
                        {
                            Id = d.Id,
                            TableCode = d.TableCode,
                            TableGroupId = d.TableGroupId,
                            TopLocation = d.TopLocation,
                            LeftLocation = d.LeftLocation

                        };
            return Table.ToList();
        }

        // ===========
        // ADD Table
        // ===========
        [Route("api/table/add")]
        public int Post(Models.MstTable table)
        {
            try
            {

                Data.MstTable newTable = new Data.MstTable();

                //
                newTable.TableCode = table.TableCode;
                newTable.TableGroupId = table.TableGroupId;
                newTable.TopLocation = table.TopLocation;
                newTable.LeftLocation = table.LeftLocation;
                //

                db.MstTables.InsertOnSubmit(newTable);
                db.SubmitChanges();

                return newTable.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Table
        // ==============
        [Route("api/table/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstTable table)
        {
            try
            {

                var TableId = Convert.ToInt32(id);
                var Table = from d in db.MstTables where d.Id == TableId select d;

                if (Table.Any())
                {
                    var updateTable = Table.FirstOrDefault();

                    //
                    updateTable.TableCode = table.TableCode;
                    updateTable.TableGroupId = table.TableGroupId;
                    updateTable.TopLocation = table.TopLocation;
                    updateTable.LeftLocation = table.LeftLocation;
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
        // DELETE Table
        // ==============
        [Route("api/table/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var TableId = Convert.ToInt32(id);
                var Table = from d in db.MstTables where d.Id == TableId select d;

                if (Table.Any())
                {
                    db.MstTables.DeleteOnSubmit(Table.First());
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