using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnCollection
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public DateTime CollectionDate { get; set; }
        public String CollectionNumber { get; set; }
        public Int32 TerminalId { get; set; }
        public String ManualORNumber { get; set; }
        public Int32 CustomerId { get; set; }
        public String Remarks { get; set; }
        public Int32 SalesId { get; set; }
        public Decimal SalesBalanceAmount { get; set; }
        public Decimal Amount { get; set; }
        public Decimal TenderAmount { get; set; }
        public Decimal ChangeAmount { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckedBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsCancelled { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }

    }
}