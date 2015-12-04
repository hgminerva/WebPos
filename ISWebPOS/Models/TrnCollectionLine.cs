using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnCollectionLine
    {

        public Int32 Id { get; set; }
        public Int32 CollectionId { get; set; }
        public Decimal Amount { get; set; }
        public Int32 PayTypeId { get; set; }
        public String CheckNumber { get; set; }
        public String CheckDate { get; set; }
        public String CheckBank { get; set; }
        public String CreditCardVerificationCode { get; set; }
        public String CreditCardNumber { get; set; }
        public String CreditCardType { get; set; }
        public String CreditCardBank { get; set; }
        public String GiftCertificateNumber { get; set; }
        public String OtherInformation { get; set; }
        public Int32? StockInId { get; set; }
        public Int32 AccountId { get; set; }
        public String CreditCardReferenceNumber { get; set; }
        public String CreditCardHolderName { get; set; }
        public String CreditCardExpiry { get; set; }

    }
}