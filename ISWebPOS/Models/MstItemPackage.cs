using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstItemPackage
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 PackageItemId { get; set; }
        public Int32 UnitId { get; set; }
        public Double Quantity { get; set; }
        public Boolean IsOptional { get; set; }
    }
}