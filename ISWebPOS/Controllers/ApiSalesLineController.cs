using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiSalesLineController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST SalesLine
        // ===========
        [Route("api/salesLine/list")]
        public List<Models.TrnSalesLine> Get()
        {
            var salesLine = from d in db.TrnSalesLines
                        select new Models.TrnSalesLine
                        {
                            Id = d.Id,
                            SalesId = d.SalesId,
                            ItemId = d.ItemId,
                            UnitId = d.UnitId,
                            Price = d.Price,
                            DiscountId = d.DiscountId,
                            DiscountRate = d.DiscountRate,
                            DiscountAmount = d.DiscountAmount,
                            NetPrice = d.NetPrice,
                            Quantity = d.Quantity,
                            Amount = d.Amount,
                            TaxId = d.TaxId,
                            TaxRate = d.TaxRate,
                            TaxAmount = d.TaxAmount,
                            SalesAccountId = d.SalesAccountId,
                            AssetAccountId = d.AssetAccountId,
                            CostAccountId = d.CostAccountId,
                            TaxAccountId = d.TaxAccountId,
                            SalesLineTimeStamp = Convert.ToString(d.SalesLineTimeStamp),
                            UserId = d.UserId,
                            Preparation = d.Preparation

                        };
            return salesLine.ToList();
        }

        // ===========
        // ADD SalesLine
        // ===========
        [Route("api/salesLine/add")]
        public int Post(Models.TrnSalesLine saleLine)
        {
            try
            {
                

                Data.TrnSalesLine newSaleLine = new Data.TrnSalesLine();

                newSaleLine.SalesId = saleLine.SalesId;
                newSaleLine.ItemId = saleLine.ItemId;
                newSaleLine.UnitId = saleLine.UnitId;
                newSaleLine.Price = saleLine.Price;
                newSaleLine.DiscountId = saleLine.DiscountId;
                newSaleLine.DiscountRate = saleLine.DiscountRate;
                newSaleLine.DiscountAmount = saleLine.DiscountAmount;
                newSaleLine.NetPrice = saleLine.NetPrice;
                newSaleLine.Quantity = saleLine.Quantity;
                newSaleLine.Amount = saleLine.Amount;
                newSaleLine.TaxId = saleLine.TaxId;
                newSaleLine.TaxRate = saleLine.TaxRate;
                newSaleLine.TaxAmount = saleLine.TaxAmount;
                newSaleLine.SalesAccountId = saleLine.SalesAccountId;
                newSaleLine.AssetAccountId = saleLine.AssetAccountId;
                newSaleLine.CostAccountId = saleLine.CostAccountId;
                newSaleLine.TaxAccountId = saleLine.TaxAccountId;
                newSaleLine.SalesLineTimeStamp = Convert.ToDateTime(saleLine.SalesLineTimeStamp);
                newSaleLine.UserId = saleLine.UserId;
                newSaleLine.Preparation = saleLine.Preparation;


                db.TrnSalesLines.InsertOnSubmit(newSaleLine);
                db.SubmitChanges();

                return newSaleLine.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE SalesLine
        // ==============
        [Route("api/salesLine/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnSalesLine saleLine)
        {
            try
            {

                var saleLineId = Convert.ToInt32(id);
                var salesLines = from d in db.TrnSalesLines where d.Id == saleLineId select d;

                if (salesLines.Any())
                {
                    var updateSalesLine = salesLines.FirstOrDefault();

                    updateSalesLine.SalesId = saleLine.SalesId;
                    updateSalesLine.ItemId = saleLine.ItemId;
                    updateSalesLine.UnitId = saleLine.UnitId;
                    updateSalesLine.Price = saleLine.Price;
                    updateSalesLine.DiscountId = saleLine.DiscountId;
                    updateSalesLine.DiscountRate = saleLine.DiscountRate;
                    updateSalesLine.DiscountAmount = saleLine.DiscountAmount;
                    updateSalesLine.NetPrice = saleLine.NetPrice;
                    updateSalesLine.Quantity = saleLine.Quantity;
                    updateSalesLine.Amount = saleLine.Amount;
                    updateSalesLine.TaxId = saleLine.TaxId;
                    updateSalesLine.TaxRate = saleLine.TaxRate;
                    updateSalesLine.TaxAmount = saleLine.TaxAmount;
                    updateSalesLine.SalesAccountId = saleLine.SalesAccountId;
                    updateSalesLine.AssetAccountId = saleLine.AssetAccountId;
                    updateSalesLine.CostAccountId = saleLine.CostAccountId;
                    updateSalesLine.TaxAccountId = saleLine.TaxAccountId;
                    updateSalesLine.SalesLineTimeStamp = Convert.ToDateTime(saleLine.SalesLineTimeStamp);
                    updateSalesLine.UserId = saleLine.UserId;
                    updateSalesLine.Preparation = saleLine.Preparation;

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
        // DELETE SalesLine
        // ==============
        [Route("api/salesLine/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var saleLineId = Convert.ToInt32(id);
                var salesLines = from d in db.TrnSalesLines where d.Id == saleLineId select d;

                if (salesLines.Any())
                {
                    db.TrnSalesLines.DeleteOnSubmit(salesLines.First());
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