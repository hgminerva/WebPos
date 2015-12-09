using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemGroupController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST ItemGroup
        // ===========
        [Route("api/itemgroup/list")]
        public List<Models.MstItemGroup> Get()
        {
            var isLocked = true;
            var itemGroup = from d in db.MstItemGroups
                            select new Models.MstItemGroup
                            {
                                Id = d.Id,
                                ItemGroup = d.ItemGroup,
                                ImagePath = d.ImagePath,
                                KitchenReport = d.KitchenReport,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = Convert.ToString(d.EntryDateTime),
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = Convert.ToString(d.UpdateDateTime),
                                IsLocked = isLocked
                            };
            return itemGroup.ToList();
        }

        // ===========
        // ADD ItemGroup
        // ===========
        [Route("api/itemgroup/add")]
        public int Post(Models.MstItemGroup itemgroup)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstItemGroup newItemGroup = new Data.MstItemGroup();

                //
                newItemGroup.ItemGroup = itemgroup.ItemGroup;
                newItemGroup.ImagePath = itemgroup.ImagePath;
                newItemGroup.KitchenReport = itemgroup.KitchenReport;
                newItemGroup.EntryUserId = mstUserId;
                newItemGroup.EntryDateTime = date;

                newItemGroup.UpdateUserId = mstUserId;
                newItemGroup.UpdateDateTime = date;
                newItemGroup.IsLocked = isLocked;
                //

                db.MstItemGroups.InsertOnSubmit(newItemGroup);
                db.SubmitChanges();

                return newItemGroup.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE ItemGroup
        // ==============
        [Route("api/itemgroup/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItemGroup itemgroup)
        {
            try
            {

                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var itemGrouptId = Convert.ToInt32(id);
                var itemGroup = from d in db.MstItemGroups where d.Id == itemGrouptId select d;

                if (itemGroup.Any())
                {
                    var updateItemGroup = itemGroup.FirstOrDefault();

                    //
                    updateItemGroup.ItemGroup = itemgroup.ItemGroup;
                    updateItemGroup.ImagePath = itemgroup.ImagePath;
                    updateItemGroup.KitchenReport = itemgroup.KitchenReport;

                    updateItemGroup.UpdateUserId = mstUserId;
                    updateItemGroup.UpdateDateTime = date;
                    updateItemGroup.IsLocked = isLocked;
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
        // DELETE ItemGroup
        // ==============
        [Route("api/itemgroup/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemGrouptId = Convert.ToInt32(id);
                var itemGroup = from d in db.MstItemGroups where d.Id == itemGrouptId select d;

                if (itemGroup.Any())
                {
                    db.MstItemGroups.DeleteOnSubmit(itemGroup.First());
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