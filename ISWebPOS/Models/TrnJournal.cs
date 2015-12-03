using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnJournal
    {
        public Int32 Id { get; set; }
        public String JournalDate { get; set; }
        public String JournalRefDocument { get; set; }
        public Int32 AccountId { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal CreditAmount { get; set; }
        public Int32? SalesId { get; set; }
        public Int32? StockInId { get; set; }
        public Int32? StockOutId { get; set; }
        public Int32? CollectionId { get; set; }
        public Int32? DCMemoId { get; set; }
        public Int32? DisbursementId { get; set; }
    }
}