using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstDiscountItem
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 DiscountId { get; set; }
        public Int32 ItemId { get; set; }
    }
}