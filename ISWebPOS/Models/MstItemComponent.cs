using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstItemComponent
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 ComponentItemId { get; set; }
        public Int32 UnitId { get; set; }
        public Double Quantity { get; set; }
        public Double Cost { get; set; }
        public Double Amount { get; set; }
        public Boolean IsPrinted { get; set; }
    }
}