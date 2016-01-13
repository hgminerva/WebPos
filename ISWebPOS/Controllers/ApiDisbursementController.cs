using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiDisbursementController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // =================
        // LIST Disbursement
        // =================
        [Route("api/disbursement/list")]
        public List<Models.TrnDisbursement> Get()
        {
            var isLocked = true;

            var Disbursement = from d in db.TrnDisbursements
                               select new Models.TrnDisbursement
                               {
                                   Id = d.Id,
                                   PeriodId = d.PeriodId,
                                   DisbursementDate = Convert.ToString(d.DisbursementDate),
                                   DisbursementNumber = d.DisbursementNumber,
                                   DisbursementType = d.DisbursementType,
                                   AccountId = d.AccountId,
                                   Amount = d.Amount,
                                   PayTypeId = d.PayTypeId,
                                   TerminalId = d.TerminalId,
                                   Remarks = d.Remarks,
                                   IsReturn = d.IsReturn,
                                   StockInId = d.StockInId,
                                   PreparedBy = d.PreparedBy,
                                   CheckedBy = d.CheckedBy,
                                   ApprovedBy = d.ApprovedBy,
                                   IsLocked = isLocked,
                                   EntryUserId = d.EntryUserId,
                                   EntryDateTime = d.EntryDateTime,
                                   UpdateUserId = d.UpdateUserId,
                                   UpdateDateTime = d.UpdateDateTime,
                                   Amount1000 = d.Amount1000,
                                   Amount500 = d.Amount500,
                                   Amount200 = d.Amount200,
                                   Amount100 = d.Amount100,
                                   Amount50 = d.Amount50,
                                   Amount20 = d.Amount20,
                                   Amount10 = d.Amount10,
                                   Amount5 = d.Amount5,
                                   Amount1 = d.Amount1,
                                   Amount025 = d.Amount025,
                                   Amount010 = d.Amount010,
                                   Amount005 = d.Amount005,
                                   Amount001 = d.Amount001,
                                   Payee = d.Payee
                               };
            return Disbursement.ToList();
        }

        // ================
        // ADD Disbursement
        // ================
        [Route("api/disbursement/add")]
        public int Post(Models.TrnDisbursement disbursement)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.TrnDisbursement newDisbursement = new Data.TrnDisbursement();

                newDisbursement.PeriodId = disbursement.PeriodId;
                newDisbursement.DisbursementDate = Convert.ToDateTime(disbursement.DisbursementDate);
                newDisbursement.DisbursementNumber = disbursement.DisbursementNumber;
                newDisbursement.DisbursementType = disbursement.DisbursementType;
                newDisbursement.AccountId = disbursement.AccountId;
                newDisbursement.Amount = disbursement.Amount;
                newDisbursement.PayTypeId = disbursement.PayTypeId;
                newDisbursement.TerminalId = disbursement.TerminalId;
                newDisbursement.Remarks = disbursement.Remarks;                
                newDisbursement.IsReturn = disbursement.IsReturn;
                newDisbursement.StockInId = disbursement.StockInId;
                newDisbursement.PreparedBy = disbursement.PreparedBy;
                newDisbursement.CheckedBy = disbursement.CheckedBy;
                newDisbursement.ApprovedBy = disbursement.ApprovedBy;
                newDisbursement.IsLocked = isLocked;
                newDisbursement.EntryUserId = mstUserId;
                newDisbursement.EntryDateTime = date;
                newDisbursement.UpdateUserId = mstUserId;
                newDisbursement.UpdateDateTime = date;
                newDisbursement.Amount1000 = disbursement.Amount1000;
                newDisbursement.Amount500 = disbursement.Amount500;
                newDisbursement.Amount200 = disbursement.Amount200;
                newDisbursement.Amount100 = disbursement.Amount100;
                newDisbursement.Amount50 = disbursement.Amount50;
                newDisbursement.Amount20 = disbursement.Amount20;
                newDisbursement.Amount10 = disbursement.Amount10;
                newDisbursement.Amount5 = disbursement.Amount5;
                newDisbursement.Amount1 = disbursement.Amount1;
                newDisbursement.Amount025 = disbursement.Amount025;
                newDisbursement.Amount010 = disbursement.Amount010;
                newDisbursement.Amount005 = disbursement.Amount005;
                newDisbursement.Amount001 = disbursement.Amount001;
                newDisbursement.Payee = disbursement.Payee;                

                db.TrnDisbursements.InsertOnSubmit(newDisbursement);
                db.SubmitChanges();

                return newDisbursement.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ===================
        // UPDATE Disbursement
        // ===================
        [Route("api/disbursement/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnDisbursement disbursement)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var DisbursementId = Convert.ToInt32(id);
                var Disbursement = from d in db.TrnDisbursements where d.Id == DisbursementId select d;

                if (Disbursement.Any())
                {
                    var updateDisbursement = Disbursement.FirstOrDefault();

                    updateDisbursement.PeriodId = disbursement.PeriodId;
                    updateDisbursement.DisbursementDate = Convert.ToDateTime(disbursement.DisbursementDate);
                    updateDisbursement.DisbursementNumber = disbursement.DisbursementNumber;
                    updateDisbursement.DisbursementType = disbursement.DisbursementType;
                    updateDisbursement.AccountId = disbursement.AccountId;
                    updateDisbursement.Amount = disbursement.Amount;
                    updateDisbursement.PayTypeId = disbursement.PayTypeId;
                    updateDisbursement.TerminalId = disbursement.TerminalId;
                    updateDisbursement.Remarks = disbursement.Remarks;
                    updateDisbursement.IsReturn = disbursement.IsReturn;
                    updateDisbursement.StockInId = disbursement.StockInId;
                    updateDisbursement.PreparedBy = disbursement.PreparedBy;
                    updateDisbursement.CheckedBy = disbursement.CheckedBy;
                    updateDisbursement.ApprovedBy = disbursement.ApprovedBy;
                    updateDisbursement.IsLocked = isLocked;
                    updateDisbursement.EntryUserId = mstUserId;
                    updateDisbursement.EntryDateTime = date;
                    updateDisbursement.UpdateUserId = mstUserId;
                    updateDisbursement.UpdateDateTime = date;
                    updateDisbursement.Amount1000 = disbursement.Amount1000;
                    updateDisbursement.Amount500 = disbursement.Amount500;
                    updateDisbursement.Amount200 = disbursement.Amount200;
                    updateDisbursement.Amount100 = disbursement.Amount100;
                    updateDisbursement.Amount50 = disbursement.Amount50;
                    updateDisbursement.Amount20 = disbursement.Amount20;
                    updateDisbursement.Amount10 = disbursement.Amount10;
                    updateDisbursement.Amount5 = disbursement.Amount5;
                    updateDisbursement.Amount1 = disbursement.Amount1;
                    updateDisbursement.Amount025 = disbursement.Amount025;
                    updateDisbursement.Amount010 = disbursement.Amount010;
                    updateDisbursement.Amount005 = disbursement.Amount005;
                    updateDisbursement.Amount001 = disbursement.Amount001;
                    updateDisbursement.Payee = disbursement.Payee;

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

        // ===================
        // DELETE Disbursement
        // ===================
        [Route("api/disbursement/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var disbursementId = Convert.ToInt32(id);
                var disbursement = from d in db.TrnDisbursements where d.Id == disbursementId select d;

                if (disbursement.Any())
                {
                    db.TrnDisbursements.DeleteOnSubmit(disbursement.First());
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