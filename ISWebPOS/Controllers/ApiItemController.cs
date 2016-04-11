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
        // Get Item
        // =========== 

        [Route("api/item/search/{id}")]
        public List<Models.MstItem> GetItem(String id)
        {
            var isLocked = true;

            var ID = Convert.ToInt32(id);
            var item = from d in db.MstItems
                       where d.Id == ID
                       select new Models.MstItem
                       {
                           Id = d.Id,
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
                           isLocked = d.IsLocked
                       };

            return item.ToList();
        }

        [Route("api/item/barcode/{barcode}")]
        public List<Models.MstItem> GetItemByBarcode(String barcode)
        {
            var isLocked = true;

            var item = from d in db.MstItems
                       where d.BarCode == barcode
                       select new Models.MstItem
                       {
                           Id = d.Id,
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
                           isLocked = d.IsLocked
                       };

            return item.ToList();
        }

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
                           Id = d.Id,
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
        public HttpResponseMessage Post(Models.MstItem item)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = 1;// (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstItem newItem = new Data.MstItem();

                newItem.ItemCode = item.ItemCode != null ? item.ItemCode : "00000";
                newItem.BarCode = item.BarCode != null ? item.BarCode : "00000";
                newItem.ItemDescription = item.ItemDescription != null ? item.ItemDescription : "00000";
                newItem.Alias = item.Alias != null ? item.Alias : "00000";
                newItem.GenericName = item.GenericName != null ? item.GenericName : "00000";
                newItem.Category = item.Category != null ? item.Category : "00000";
                newItem.SalesAccountId = item.SalesAccountId != null ? item.SalesAccountId : 0;
                newItem.AssetAccountId = item.AssetAccountId != null ? item.AssetAccountId : 0;
                newItem.CostAccountId = item.CostAccountId != null ? item.CostAccountId : 0;
                newItem.InTaxId = item.InTaxId != null ? item.InTaxId : 0;
                newItem.OutTaxId = item.OutTaxId != null ? item.OutTaxId : 0;
                newItem.UnitId = item.UnitId != null ? item.UnitId : 0;
                newItem.DefaultSupplierId = item.DefaultSupplierId != null ? item.DefaultSupplierId : 0;
                newItem.Cost = item.Cost != null ? item.Cost : 0;
                newItem.MarkUp = item.MarkUp != null ? item.MarkUp : 0;
                newItem.Price = item.Price != null ? item.Price : 0;
                newItem.ImagePath = item.ImagePath != null ? item.ImagePath : "00000";
                newItem.ReorderQuantity = item.ReorderQuantity != null ? item.ReorderQuantity : 0;
                newItem.OnhandQuantity = item.OnhandQuantity != null ? item.OnhandQuantity : 0;
                newItem.IsInventory = item.IsInventory != null ? item.IsInventory : false;
                newItem.IsPackage = item.IsPackage != null ? item.IsPackage : false;
                newItem.EntryUserId = mstUserId;
                newItem.EntryDateTime = date;
                newItem.UpdateUserId = mstUserId;
                newItem.UpdateDateTime = date;
                newItem.IsLocked = isLocked != null ? isLocked : false;

                //ALLOW NULL
                newItem.ExpiryDate = date;
                newItem.LotNumber = item.LotNumber;
                newItem.Remarks = item.Remarks;
                newItem.DefaultKitchenReport = item.DefaultKitchenReport;

                db.MstItems.InsertOnSubmit(newItem);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
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
                    updateItem.ExpiryDate = Convert.ToDateTime(DateTime.Now);
                    updateItem.LotNumber = item.LotNumber;
                    updateItem.Remarks = item.Remarks;
                    updateItem.DefaultKitchenReport = item.DefaultKitchenReport;
                    updateItem.IsPackage = item.IsPackage;

                    updateItem.UpdateUserId = 123;
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
