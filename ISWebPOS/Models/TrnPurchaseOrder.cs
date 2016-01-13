using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnPurchaseOrder
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public String PurchaseOrderDate { get; set; }
        public String PurchaseOrderNumber { get; set; }
        public Decimal Amount { get; set; }
        public Int32 SupplierId { get; set; }
        public String Remarks { get; set; }
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