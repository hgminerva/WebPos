﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstItemInventory
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public String InventoryDate { get; set; }
        public Decimal Quantity { get; set; }
    }
}