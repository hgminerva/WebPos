using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ISWebPOS.Models
{
    public class TrnStockOut
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public String StockOutDate { get; set; }
        public String StockOutNumber { get; set; }
        public Int32 AccountId { get; set; }
        public String Remarks { get; set; }
        public Int32 PreparedBy { get; set; }
        public Int32 CheckBy { get; set; }
        public Int32 ApprovedBy { get; set; }
        public Boolean IsLocked { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public String UpdateDateTime { get; set; }
    }
}