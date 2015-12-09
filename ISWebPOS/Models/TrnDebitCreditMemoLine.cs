using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnDebitCreditMemoLine
    {
        public Int32 Id { get; set; }
        public Int32 DCMemoId { get; set; }
        public Int32? SalesId { get; set; }
        public Int32 AccountId { get; set; }
        public String Particulars { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal CreditAmount { get; set; }
    }
}