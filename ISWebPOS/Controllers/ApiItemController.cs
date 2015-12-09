using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiItemController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Item
        // =========== 























































        [Route("api/item/list")]
        public List<Models.MstItem> Get()
        {
            var isLocked = true;

            var item = from d in db.MstItems
                           select new Models.MstItem
                           {

                               ItemCode = d.ItemCode,
                               BarCode = d.BarCode,
                               ItemDescription = d.ItemDescription,
                               Alias = d.Alias,
                               GenericName = d.GenericName,
                               Category = d.Category,
                               SalesAccountId = d.SalesAccountId,
                               AssetAccountId = d.AssetAccountId,
                               CostAccountId = d.CostAccountId,
                               InTaxId = d.InTaxId,
                               OutTaxId = d.OutTaxId,
                               UnitId = d.UnitId,
                               DefaultSupplierId = d.DefaultSupplierId,
                               Cost = d.Cost,
                               MarkUp = d.MarkUp,
                               Price = d.Price,
                               ImagePath = d.ImagePath,
                               ReorderQuantity = d.ReorderQuantity,
                               OnhandQuantity = d.OnhandQuantity,
                               IsInventory = d.IsInventory,
                               ExpiryDate = Convert.ToString(d.ExpiryDate),
                               LotNumber = d.LotNumber,
                               Remarks = d.Remarks,
                               DefaultKitchenReport = d.DefaultKitchenReport,
                               IsPackage = d.IsPackage,

                               EntryUserId = d.EntryUserId,
                               EntryDateTime = Convert.ToString(d.EntryDateTime),
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = Convert.ToString(d.UpdateDateTime),
                               isLocked = isLocked
            
                           };
            return item.ToList();
        }

        // ===========
        // ADD Item
        // ===========
        [Route("api/item/add")]
        public int Post(Models.MstItem item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstItem newItem = new Data.MstItem();

                newItem.ItemCode = item.ItemCode;
                newItem.BarCode = item.BarCode;
                newItem.ItemDescription = item.ItemDescription;
                newItem.Alias = item.Alias;
                newItem.GenericName = item.GenericName;
                newItem.Category = item.Category;
                newItem.SalesAccountId = item.SalesAccountId;
                newItem.AssetAccountId = item.AssetAccountId;
                newItem.CostAccountId = item.CostAccountId;
                newItem.InTaxId = item.InTaxId;
                newItem.OutTaxId = item.OutTaxId;
                newItem.UnitId = item.UnitId;
                newItem.DefaultSupplierId = item.DefaultSupplierId;
                newItem.Cost = item.Cost;
                newItem.MarkUp = item.MarkUp;
                newItem.Price = item.Price;
                newItem.ImagePath = item.ImagePath;
                newItem.ReorderQuantity = item.ReorderQuantity;
                newItem.OnhandQuantity = item.OnhandQuantity;
                newItem.IsInventory = item.IsInventory;
                newItem.ExpiryDate = Convert.ToDateTime(item.ExpiryDate);
                newItem.LotNumber = item.LotNumber;
                newItem.Remarks = item.Remarks;
                newItem.DefaultKitchenReport = item.DefaultKitchenReport;
                newItem.IsPackage = item.IsPackage;

                newItem.EntryUserId = mstUserId;
                newItem.EntryDateTime = date;
                newItem.UpdateUserId = mstUserId;
                newItem.UpdateDateTime = date;
                newItem.IsLocked = isLocked;

                db.MstItems.InsertOnSubmit(newItem);
                db.SubmitChanges();

                return newItem.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Item
        // ==============
        [Route("api/item/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstItem item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var itemId = Convert.ToInt32(id);
                var items = from d in db.MstItems where d.Id == itemId select d;

                if (items.Any())
                {
                    var updateItem = items.FirstOrDefault();

                    updateItem.ItemCode = item.ItemCode;
                    updateItem.BarCode = item.BarCode;
                    updateItem.ItemDescription = item.ItemDescription;
                    updateItem.Alias = item.Alias;
                    updateItem.GenericName = item.GenericName;
                    updateItem.Category = item.Category;
                    updateItem.SalesAccountId = item.SalesAccountId;
                    updateItem.AssetAccountId = item.AssetAccountId;
                    updateItem.CostAccountId = item.CostAccountId;
                    updateItem.InTaxId = item.InTaxId;
                    updateItem.OutTaxId = item.OutTaxId;
                    updateItem.UnitId = item.UnitId;
                    updateItem.DefaultSupplierId = item.DefaultSupplierId;
                    updateItem.Cost = item.Cost;
                    updateItem.MarkUp = item.MarkUp;
                    updateItem.Price = item.Price;
                    updateItem.ImagePath = item.ImagePath;
                    updateItem.ReorderQuantity = item.ReorderQuantity;
                    updateItem.OnhandQuantity = item.OnhandQuantity;
                    updateItem.IsInventory = item.IsInventory;
                    updateItem.ExpiryDate = Convert.ToDateTime(item.ExpiryDate);
                    updateItem.LotNumber = item.LotNumber;
                    updateItem.Remarks = item.Remarks;
                    updateItem.DefaultKitchenReport = item.DefaultKitchenReport;
                    updateItem.IsPackage = item.IsPackage;

                    updateItem.UpdateUserId = mstUserId;
                    updateItem.UpdateDateTime = date;
                    updateItem.IsLocked = isLocked;

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
        // DELETE Item
        // ==============
        [Route("api/item/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var itemId = Convert.ToInt32(id);
                var items = from d in db.MstItems where d.Id == itemId select d;

                if (items.Any())
                {
                    db.MstItems.DeleteOnSubmit(items.First());
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
