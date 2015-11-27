using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstItemGroupItem
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 ItemGroupId { get; set; }
    }
}