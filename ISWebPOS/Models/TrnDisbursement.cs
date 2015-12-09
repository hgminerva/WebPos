using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnDisbursement
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public String DisbursementDate { get; set; }
        public String DisbursementNumber { get; set; }
        public String DisbursementType { get; set; }
        public Int32 AccountId { get; set; }
        public Decimal Amount { get; set; }
        public Int32 PayTypeId { get; set; }
        public Int32 TerminalId { get; set; }
        public String Remarks { get; set; }
        public Boolean IsReturn { get; set; }
        public Int32? StockInId { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckedBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Decimal? Amount1000 { get; set; }
        public Decimal? Amount500 { get; set; }
        public Decimal? Amount200 { get; set; }
        public Decimal? Amount100 { get; set; }
        public Decimal? Amount50 { get; set; }
        public Decimal? Amount20 { get; set; }
        public Decimal? Amount10 { get; set; }
        public Decimal? Amount5 { get; set; }
        public Decimal? Amount1 { get; set; }
        public Decimal? Amount025 { get; set; }
        public Decimal? Amount010 { get; set; }
        public Decimal? Amount005{ get; set; }
        public Decimal? Amount001{ get; set; }
        public String Payee { get; set; }
    }
}