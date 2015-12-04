using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;


namespace ISWebPOS.Controllers
{
    public class ApiDebitCreditMemoController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST DebitCreditMemo
        // ===========
        [Route("api/debitcreditmemo/list")]
        public List<Models.TrnDebitCreditMemo> Get()
        {
            var isLocked = true;
            var DebitCreditMemo = from d in db.TrnDebitCreditMemos
                          select new Models.TrnDebitCreditMemo
                          {
                              Id = d.Id,
                              PeriodId = d.PeriodId,
                              DCMemoNumber = d.DCMemoNumber,
                              DCMemoDate = Convert.ToString(d.DCMemoDate),
                              Particulars = d.Particulars,
                              PreparedBy = d.PreparedBy,
                              CheckedBy = d.CheckedBy,
                              ApprovedBy = d.ApprovedBy,
                              IsLocked = isLocked,
                              EntryUserId = d.EntryUserId,
                              EntryDateTime = Convert.ToString(d.EntryDateTime),
                              UpdateUserId = d.UpdateUserId,
                              UpdateDateTime = Convert.ToString(d.UpdateDateTime)
                          };
            return DebitCreditMemo.ToList();
        }

        // ===========
        // ADD DebitCreditMemo
        // ===========
        [Route("api/debitcreditmemo/add")]
        public int Post(Models.TrnDebitCreditMemo debitcreditmemo)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnDebitCreditMemo newDebitCreditMemo = new Data.TrnDebitCreditMemo();

                //
                newDebitCreditMemo.PeriodId = debitcreditmemo.PeriodId;
                newDebitCreditMemo.DCMemoNumber = debitcreditmemo.DCMemoNumber;
                newDebitCreditMemo.DCMemoDate = Convert.ToDateTime(debitcreditmemo.DCMemoDate);
                newDebitCreditMemo.Particulars = debitcreditmemo.Particulars;
                newDebitCreditMemo.PreparedBy = debitcreditmemo.PreparedBy;
                newDebitCreditMemo.CheckedBy = debitcreditmemo.CheckedBy;
                newDebitCreditMemo.ApprovedBy = debitcreditmemo.ApprovedBy;
                newDebitCreditMemo.IsLocked = isLocked;
                newDebitCreditMemo.EntryUserId = mstUserId;
                newDebitCreditMemo.EntryDateTime = date;
                newDebitCreditMemo.UpdateDateTime = date;
                newDebitCreditMemo.UpdateUserId = mstUserId;
                //

                db.TrnDebitCreditMemos.InsertOnSubmit(newDebitCreditMemo);
                db.SubmitChanges();

                return newDebitCreditMemo.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE DebitCreditMemo
        // ==============
        [Route("api/debitcreditmemo/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnDebitCreditMemo debitcreditmemo)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var DebitCreditMemoId = Convert.ToInt32(id);
                var DebitCreditMemo = from d in db.TrnDebitCreditMemos where d.Id == DebitCreditMemoId select d;

                if (DebitCreditMemo.Any())
                {
                    var updateDebitCreditMemo = DebitCreditMemo.FirstOrDefault();

                    //
                    updateDebitCreditMemo.PeriodId = debitcreditmemo.PeriodId;
                    updateDebitCreditMemo.DCMemoNumber = debitcreditmemo.DCMemoNumber;
                    updateDebitCreditMemo.DCMemoDate = Convert.ToDateTime(debitcreditmemo.DCMemoDate);
                    updateDebitCreditMemo.Particulars = debitcreditmemo.Particulars;
                    updateDebitCreditMemo.PreparedBy = debitcreditmemo.PreparedBy;
                    updateDebitCreditMemo.CheckedBy = debitcreditmemo.CheckedBy;
                    updateDebitCreditMemo.ApprovedBy = debitcreditmemo.ApprovedBy;
                    updateDebitCreditMemo.IsLocked = isLocked;
                    updateDebitCreditMemo.UpdateDateTime = date;
                    updateDebitCreditMemo.UpdateUserId = mstUserId;
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
        // DELETE DebitCreditMemo
        // ==============
        [Route("api/debitcreditmemo/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var DebitCreditMemoId = Convert.ToInt32(id);
                var DebitCreditMemo = from d in db.TrnDebitCreditMemos where d.Id == DebitCreditMemoId select d;

                if (DebitCreditMemo.Any())
                {
                    db.TrnDebitCreditMemos.DeleteOnSubmit(DebitCreditMemo.First());
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