using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace ISWebPOS.Controllers
{
    public class ApiCollectionController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Collection
        // ===========
        [Route("api/collection/list")]
        public List<Models.TrnCollection> Get()
        {
            var isLocked = true;
            var Collection = from d in db.TrnCollections
                                 select new Models.TrnCollection
                                 {
                                     Id = d.Id,
                                     PeriodId = d.PeriodId,
                                     CollectionDate = Convert.ToString(d.CollectionDate),
                                     CollectionNumber = d.CollectionNumber,
                                     TerminalId = d.TerminalId,
                                     ManualORNumber = d.ManualORNumber,
                                     CustomerId = d.CustomerId,
                                     Remarks = d.Remarks,
                                     SalesId = d.SalesId,
                                     SalesBalanceAmount = d.SalesBalanceAmount,
                                     Amount = d.Amount,
                                     TenderAmount = d.TenderAmount,
                                     ChangeAmount = d.ChangeAmount,
                                     PreparedBy = d.PreparedBy,
                                     CheckedBy = d.CheckedBy,
                                     ApprovedBy = d.ApprovedBy,
                                     IsCancelled = d.IsCancelled,
                                     IsLocked = isLocked,
                                     EntryUserId = d.EntryUserId,
                                     EntryDateTime = d.EntryDateTime,
                                     UpdateUserId = d.UpdateUserId,
                                     UpdateDateTime = d.UpdateDateTime
                                 };
            return Collection.ToList();
        }

        // ===========
        // ADD Collection
        // ===========
        [Route("api/collection/add")]
        public int Post(Models.TrnCollection collection)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnCollection newCollection = new Data.TrnCollection();

                //
                newCollection.PeriodId = collection.PeriodId;
                newCollection.CollectionDate = Convert.ToDateTime(collection.CollectionDate);
                newCollection.CollectionNumber = collection.CollectionNumber;
                newCollection.TerminalId = collection.TerminalId;
                newCollection.ManualORNumber = collection.ManualORNumber;
                newCollection.CustomerId = collection.CustomerId;
                newCollection.Remarks = collection.Remarks;
                newCollection.SalesId = collection.SalesId;
                newCollection.SalesBalanceAmount = collection.SalesBalanceAmount;
                newCollection.Amount = collection.Amount;
                newCollection.TenderAmount = collection.TenderAmount;
                newCollection.ChangeAmount = collection.ChangeAmount;
                newCollection.PreparedBy = collection.PreparedBy;
                newCollection.CheckedBy = collection.CheckedBy;
                newCollection.ApprovedBy = collection.ApprovedBy;
                newCollection.IsCancelled = collection.IsCancelled;
                newCollection.IsLocked = isLocked;
                newCollection.EntryUserId = mstUserId;
                newCollection.EntryDateTime = date;
                newCollection.UpdateUserId = mstUserId;
                newCollection.UpdateDateTime = date;
                //

                db.TrnCollections.InsertOnSubmit(newCollection);
                db.SubmitChanges();

                return newCollection.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Collection
        // ==============
        [Route("api/collection/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnCollection collection)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var CollectionId = Convert.ToInt32(id);
                var Collection = from d in db.TrnCollections where d.Id == CollectionId select d;

                if (Collection.Any())
                {
                    var updateCollection = Collection.FirstOrDefault();

                    //
                    updateCollection.PeriodId = collection.PeriodId;
                    updateCollection.CollectionDate = Convert.ToDateTime(collection.CollectionDate);
                    updateCollection.CollectionNumber = collection.CollectionNumber;
                    updateCollection.TerminalId = collection.TerminalId;
                    updateCollection.ManualORNumber = collection.ManualORNumber;
                    updateCollection.CustomerId = collection.CustomerId;
                    updateCollection.Remarks = collection.Remarks;
                    updateCollection.SalesId = collection.SalesId;
                    updateCollection.SalesBalanceAmount = collection.SalesBalanceAmount;
                    updateCollection.Amount = collection.Amount;
                    updateCollection.TenderAmount = collection.TenderAmount;
                    updateCollection.ChangeAmount = collection.ChangeAmount;
                    updateCollection.PreparedBy = collection.PreparedBy;
                    updateCollection.CheckedBy = collection.CheckedBy;
                    updateCollection.ApprovedBy = collection.ApprovedBy;
                    updateCollection.IsCancelled = collection.IsCancelled;
                    updateCollection.IsLocked = isLocked;
                    updateCollection.UpdateUserId = mstUserId;
                    updateCollection.UpdateDateTime = date;
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
        // DELETE CollectionLine
        // ==============
        [Route("api/collection/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var CollectionId = Convert.ToInt32(id);
                var Collection = from d in db.TrnCollections where d.Id == CollectionId select d;

                if (Collection.Any())
                {
                    db.TrnCollections.DeleteOnSubmit(Collection.First());
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