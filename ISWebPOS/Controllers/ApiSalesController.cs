using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiSalesController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Sales
        // ===========
        [Route("api/sales/list")]
        public List<Models.TrnSales> Get()
        {
            var sales = from d in db.TrnSales
                            select new Models.TrnSales
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                SalesDate = Convert.ToString (d.SalesDate),
                                SalesNumber = d.SalesNumber,
                                ManualInvoiceNumber = d.ManualInvoiceNumber,
                                Amount = d.Amount,
                                TableId = d.TableId,
                                CustomerId = d.CustomerId,
                                AccountId = d.AccountId,
                                TermId = d.TermId,
                                DiscountId = d.DiscountId,
                                SeniorCitizenId = d.SeniorCitizenId,
                                SeniorCitizenName = d.SeniorCitizenName,
                                SeniorCitizenAge = d.SeniorCitizenAge,
                                Remarks = d.Remarks,
                                SalesAgent = d.SalesAgent,
                                TerminalId = d.TerminalId,
                                PreparedBy = d.PreparedBy,
                                CheckedBy = d.CheckedBy,
                                ApprovedBy = d.ApprovedBy,
                                IsLocked = d.IsLocked,
                                IsCancelled = d.IsCancelled,
                                PaidAmount = d.PaidAmount,
                                CreditAmount = d.CreditAmount,
                                DebitAmount = d.DebitAmount,
                                BalanceAmount = d.BalanceAmount,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = Convert.ToString (d.EntryDateTime),
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = Convert.ToString (d.UpdateDateTime),
                                Pax = d.Pax

                            };
            return sales.ToList();
        }

        // ===========
        // ADD Sales
        // ===========
        [Route("api/sales/add")]
        public int Post(Models.TrnSales sale)
        {
            try
            {
                  var isLocked = true;
                  var identityUserId = User.Identity.GetUserId();
                  var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                  var date = DateTime.Now;

                Data.TrnSale newSale = new Data.TrnSale();

                newSale.PeriodId = sale.PeriodId;
                newSale.IsLocked = isLocked;
                newSale.SalesDate = Convert.ToDateTime(sale.SalesDate);
                newSale.SalesNumber = sale.SalesNumber;
                newSale.ManualInvoiceNumber = sale.ManualInvoiceNumber;
                newSale.Amount = sale.Amount;
                newSale.TableId = sale.TableId;
                newSale.CustomerId = sale.CustomerId;
                newSale.AccountId = sale.AccountId;
                newSale.TermId = sale.TermId;
                newSale.DiscountId = sale.DiscountId;
                newSale.SeniorCitizenId = sale.SeniorCitizenId;
                newSale.SeniorCitizenName = sale.SeniorCitizenName;
                newSale.SeniorCitizenAge = sale.SeniorCitizenAge;
                newSale.Remarks = sale.Remarks;
                newSale.SalesAgent = sale.SalesAgent;
                newSale.TerminalId = sale.TerminalId;
                newSale.PreparedBy = sale.PreparedBy;
                newSale.CheckedBy = sale.CheckedBy;
                newSale.ApprovedBy = sale.ApprovedBy;
                newSale.IsCancelled = sale.IsCancelled;
                newSale.PaidAmount = sale.PaidAmount;
                newSale.CreditAmount = sale.CreditAmount;
                newSale.DebitAmount = sale.DebitAmount;
                newSale.EntryUserId = mstUserId;
                newSale.EntryDateTime = date;
                newSale.UpdateUserId = mstUserId;
                newSale.UpdateDateTime = date;
                newSale.Pax = sale.Pax;


                db.TrnSales.InsertOnSubmit(newSale);
                db.SubmitChanges();

                return newSale.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Sales
        // ==============
        [Route("api/sales/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnSales sale)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var saleId = Convert.ToInt32(id);
                var sales = from d in db.TrnSales where d.Id == saleId select d;

                if (sales.Any())
                {
                    var updateSales = sales.FirstOrDefault();

                    updateSales.PeriodId = sale.PeriodId;
                    updateSales.IsLocked = isLocked;
                    updateSales.SalesDate = Convert.ToDateTime(sale.SalesDate);
                    updateSales.SalesNumber = sale.SalesNumber;
                    updateSales.ManualInvoiceNumber = sale.ManualInvoiceNumber;
                    updateSales.Amount = sale.Amount;
                    updateSales.TableId = sale.TableId;
                    updateSales.CustomerId = sale.CustomerId;
                    updateSales.AccountId = sale.AccountId;
                    updateSales.TermId = sale.TermId;
                    updateSales.DiscountId = sale.DiscountId;
                    updateSales.SeniorCitizenId = sale.SeniorCitizenId;
                    updateSales.SeniorCitizenName = sale.SeniorCitizenName;
                    updateSales.SeniorCitizenAge = sale.SeniorCitizenAge;
                    updateSales.Remarks = sale.Remarks;
                    updateSales.SalesAgent = sale.SalesAgent;
                    updateSales.TerminalId = sale.TerminalId;
                    updateSales.PreparedBy = sale.PreparedBy;
                    updateSales.CheckedBy = sale.CheckedBy;
                    updateSales.ApprovedBy = sale.ApprovedBy;
                    updateSales.IsCancelled = sale.IsCancelled;
                    updateSales.PaidAmount = sale.PaidAmount;
                    updateSales.CreditAmount = sale.CreditAmount;
                    updateSales.DebitAmount = sale.DebitAmount;
                    updateSales.UpdateUserId = mstUserId;
                    updateSales.UpdateDateTime = date;
                    updateSales.Pax = sale.Pax;

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
        // DELETE Sales
        // ==============
        [Route("api/sales/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var saleId = Convert.ToInt32(id);
                var sales = from d in db.TrnSales where d.Id == saleId select d;

                if (sales.Any())
                {
                    db.TrnSales.DeleteOnSubmit(sales.First());
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