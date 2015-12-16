using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnSalesLine
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 SalesId { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 UnitId { get; set; }
        public Decimal Price { get; set; }
        public Int32 DiscountId { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Int32 TaxId { get; set; }
        public Decimal TaxRate { get; set; }
        public Decimal TaxAmount { get; set; }
        public Int32 SalesAccountId { get; set; }
        public Int32 AssetAccountId { get; set; }
        public Int32 CostAccountId { get; set; }
        public Int32 TaxAccountId { get; set; }
        public String SalesLineTimeStamp { get; set; }
        public Int32? UserId { get; set; }
        public String Preparation { get; set; }


    }
}