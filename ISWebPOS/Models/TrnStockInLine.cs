using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ISWebPOS.Models
{
    public class TrnStockInLine
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 StockInId { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 UniteId { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
        public String ExpiryDate { get; set; }
        public String LotNumber { get; set; }
        public Int32 AssetAccountId { get; set; }
    }
}