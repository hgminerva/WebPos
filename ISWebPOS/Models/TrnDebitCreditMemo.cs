using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnDebitCreditMemo
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public String DCMemoNumber { get; set; }
        public String DCMemoDate { get; set; }
        public String Particulars { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckedBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public String UpdateDateTime { get; set; }

    }
}