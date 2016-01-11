using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiCollectionLineController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===================
        // LIST CollectionLine
        // ===================
        [Route("api/collectionLine/list")]
        public List<Models.TrnCollectionLine> Get()
        {
            var isLocked = true;
            var CollectionLine = from d in db.TrnCollectionLines
                                  select new Models.TrnCollectionLine
                                  {
                                      Id = d.Id,
                                      CollectionId = d.CollectionId,
                                      Amount = d.Amount,
                                      PayTypeId = d.PayTypeId,
                                      CheckNumber = d.CheckNumber,
                                      CheckDate = Convert.ToString(d.CheckDate),
                                      CheckBank = d.CheckBank,
                                      CreditCardVerificationCode = d.CreditCardVerificationCode,
                                      CreditCardNumber = d.CreditCardNumber,
                                      CreditCardType = d.CreditCardType,
                                      CreditCardBank = d.CreditCardBank,
                                      GiftCertificateNumber = d.GiftCertificateNumber,
                                      OtherInformation = d.OtherInformation,
                                      StockInId = d.StockInId,
                                      AccountId = d.AccountId,
                                      CreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                      CreditCardHolderName = d.CreditCardHolderName,
                                      CreditCardExpiry = d.CreditCardExpiry
                                  };
            return CollectionLine.ToList();
        }

        // ==================
        // ADD CollectionLine
        // ==================
        [Route("api/collectionLine/add")]
        public int Post(Models.TrnCollectionLine collectionline)
        {
            try
            {
                var isLocked = true;

                Data.TrnCollectionLine newCollectionLine = new Data.TrnCollectionLine();

                //
                newCollectionLine.CollectionId = collectionline.CollectionId;
                newCollectionLine.Amount = collectionline.Amount;
                newCollectionLine.PayTypeId = collectionline.PayTypeId;
                newCollectionLine.CheckNumber = collectionline.CheckNumber;
                newCollectionLine.CheckDate = Convert.ToDateTime(collectionline.CheckDate);
                newCollectionLine.CheckBank = collectionline.CheckBank;
                newCollectionLine.CreditCardVerificationCode = collectionline.CreditCardVerificationCode;
                newCollectionLine.CreditCardNumber = collectionline.CreditCardNumber;
                newCollectionLine.CreditCardType = collectionline.CreditCardType;
                newCollectionLine.CreditCardBank = collectionline.CreditCardBank;
                newCollectionLine.GiftCertificateNumber = collectionline.GiftCertificateNumber;
                newCollectionLine.OtherInformation = collectionline.OtherInformation;
                newCollectionLine.StockInId = collectionline.StockInId;
                newCollectionLine.AccountId = collectionline.AccountId;
                newCollectionLine.CreditCardReferenceNumber = collectionline.CreditCardReferenceNumber;
                newCollectionLine.CreditCardHolderName = collectionline.CreditCardHolderName;
                newCollectionLine.CreditCardExpiry = collectionline.CreditCardExpiry;                
                //

                db.TrnCollectionLines.InsertOnSubmit(newCollectionLine);
                db.SubmitChanges();

                return newCollectionLine.Id;
            }
            catch
            {
                return 0;
            }
        }

        // =====================
        // UPDATE CollectionLine
        // =====================
        [Route("api/collectionLine/update/{id}")]
        public HttpResponseMessage Put(String id, Models.TrnCollectionLine collectionline)
        {
            try
            {
                var CollectionLineId = Convert.ToInt32(id);
                var CollectionLine = from d in db.TrnCollectionLines where d.Id == CollectionLineId select d;

                if (CollectionLine.Any())
                {
                    var updateCollectionLine = CollectionLine.FirstOrDefault();

                    //
                    updateCollectionLine.CollectionId = collectionline.CollectionId;
                    updateCollectionLine.Amount = collectionline.Amount;
                    updateCollectionLine.PayTypeId = collectionline.PayTypeId;
                    updateCollectionLine.CheckNumber = collectionline.CheckNumber;
                    updateCollectionLine.CheckDate = Convert.ToDateTime(collectionline.CheckDate);
                    updateCollectionLine.CheckBank = collectionline.CheckBank;
                    updateCollectionLine.CreditCardVerificationCode = collectionline.CreditCardVerificationCode;
                    updateCollectionLine.CreditCardNumber = collectionline.CreditCardNumber;
                    updateCollectionLine.CreditCardType = collectionline.CreditCardType;
                    updateCollectionLine.CreditCardBank = collectionline.CreditCardBank;
                    updateCollectionLine.GiftCertificateNumber = collectionline.GiftCertificateNumber;
                    updateCollectionLine.OtherInformation = collectionline.OtherInformation;
                    updateCollectionLine.StockInId = collectionline.StockInId;
                    updateCollectionLine.AccountId = collectionline.AccountId;
                    updateCollectionLine.CreditCardReferenceNumber = collectionline.CreditCardReferenceNumber;
                    updateCollectionLine.CreditCardHolderName = collectionline.CreditCardHolderName;
                    updateCollectionLine.CreditCardExpiry = collectionline.CreditCardExpiry;
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

        // =====================
        // DELETE CollectionLine
        // =====================
        [Route("api/collectionLine/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var CollectionLineId = Convert.ToInt32(id);
                var CollectionLine = from d in db.TrnCollectionLines where d.Id == CollectionLineId select d;

                if (CollectionLine.Any())
                {
                    db.TrnCollectionLines.DeleteOnSubmit(CollectionLine.First());
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