using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ISWebPOS.Models
{
    public class TrnStockIn
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public DateTime StockInDate { get; set; }
        public String StockInNumber { get; set; }
        public Int32 SupplierId { get; set; }
        public String Remarks { get; set; }
        public Boolean IsReturn { get; set; }
        public Int32 CollectionId { get; set; }
        public Int32 PurchaseOrderId { get; set; }
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