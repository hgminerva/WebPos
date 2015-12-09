using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnSalesReleased
    {
        [Key]
        public Int32 Id { get; set; }
        public String SalesNumber { get; set; }
        public String ItemCode { get; set; }
        public Int32 ItemId { get; set; }
        public Decimal Quantity { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryDateTime { get; set; }

    }
}