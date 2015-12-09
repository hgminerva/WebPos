using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiTableGroupController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST TableGroup
        // ===========
        [Route("api/tablegroup/list")]
        public List<Models.MstTableGroup> Get()
        {
            var isLocked = true;
            var TableGroup = from d in db.MstTableGroups
                             select new Models.MstTableGroup
                             {
                                 Id = d.Id,
                                 TableGroup = d.TableGroup,
                                 EntryUserId = d.EntryUserId,
                                 EntryDateTime = Convert.ToString(d.EntryDateTime),
                                 UpdateUserId = d.UpdateUserId,
                                 UpdateDateTime = Convert.ToString(d.UpdateDateTime),
                                 IsLocked = isLocked

                             };
            return TableGroup.ToList();
        }

        // ===========
        // ADD TableGroup
        // ===========
        [Route("api/tablegroup/add")]
        public int Post(Models.MstTableGroup tablegroup)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstTableGroup newTableGroup = new Data.MstTableGroup();

                //
                newTableGroup.TableGroup = tablegroup.TableGroup;
                newTableGroup.EntryUserId = mstUserId;
                newTableGroup.EntryDateTime = date;
                newTableGroup.UpdateUserId = mstUserId;
                newTableGroup.UpdateDateTime = date;
                newTableGroup.IsLocked = isLocked;
                //

                db.MstTableGroups.InsertOnSubmit(newTableGroup);
                db.SubmitChanges();

                return newTableGroup.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE TableGroup
        // ==============
        [Route("api/tablegroup/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstTableGroup tablegroup)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var TableGroupId = Convert.ToInt32(id);
                var TableGroup = from d in db.MstTableGroups where d.Id == TableGroupId select d;

                if (TableGroup.Any())
                {
                    var updateTableGroup = TableGroup.FirstOrDefault();

                    //
                    updateTableGroup.TableGroup = tablegroup.TableGroup;
                    updateTableGroup.UpdateUserId = mstUserId;
                    updateTableGroup.UpdateDateTime = date;
                    updateTableGroup.IsLocked = isLocked;
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
        // DELETE TableGroup
        // ==============
        [Route("api/tablegroup/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var TableGroupId = Convert.ToInt32(id);
                var TableGroup = from d in db.MstTableGroups where d.Id == TableGroupId select d;

                if (TableGroup.Any())
                {
                    db.MstTableGroups.DeleteOnSubmit(TableGroup.First());
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