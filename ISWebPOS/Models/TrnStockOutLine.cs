using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ISWebPOS.Models
{
    public class TrnStockOutLine
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 StockOutId { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 UnitId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public Int32 AssetAccountId { get; set; }
    }
}