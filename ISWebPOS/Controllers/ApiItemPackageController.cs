using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemPackageController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST ItemPackage
        // ===========
        [Route("api/itempackage/list")]
        public List<Models.MstItemPackage> Get()
        {
            var itemPackage = from d in db.MstItemPackages
                                select new Models.MstItemPackage
                                {
                                    Id = d.Id,
                                    ItemId = d.ItemId,
                                    PackageItemId = d.PackageItemId,
                                    UnitId = d.UnitId,
                                    Quantity = d.Quantity,
                                    IsOptional = d.IsOptional
                                };
            return itemPackage.ToList();
        }

        // ===========
        // ADD ItemPackage
        // ===========
        [Route("api/itempackage/add")]
        public int Post(Models.MstItemPackage itempackage)
        {
            try
            {

                Data.MstItemPackage newItemPackage = new Data.MstItemPackage();

                //
                newItemPackage.ItemId = itempackage.ItemId;
                newItemPackage.PackageItemId = itempackage.PackageItemId;
                newItemPackage.UnitId = itempackage.UnitId;
                newItemPackage.Quantity = itempackage.Quantity;
                newItemPackage.IsOptional = itempackage.IsOptional;
                //

                db.MstItemPackages.InsertOnSubmit(newItemPackage);
                db.SubmitChanges();

                return newItemPackage.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE ItemPackage
        // ==============
        [Route("api/itempackage/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItemPackage itempackage)
        {
            try
            {

                var itemPackageId = Convert.ToInt32(id);
                var itemPackage = from d in db.MstItemPackages where d.Id == itemPackageId select d;

                if (itemPackage.Any())
                {
                    var updateItemPackage = itemPackage.FirstOrDefault();

                    //
                    updateItemPackage.ItemId = itempackage.ItemId;
                    updateItemPackage.PackageItemId = itempackage.PackageItemId;
                    updateItemPackage.UnitId = itempackage.UnitId;
                    updateItemPackage.Quantity = itempackage.Quantity;
                    updateItemPackage.IsOptional = itempackage.IsOptional;
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
        // DELETE ItemPackage
        // ==============
        [Route("api/itempackage/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemPackageId = Convert.ToInt32(id);
                var itemPackage = from d in db.MstItemPackages where d.Id == itemPackageId select d;

                if (itemPackage.Any())
                {
                    db.MstItemPackages.DeleteOnSubmit(itemPackage.First());
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