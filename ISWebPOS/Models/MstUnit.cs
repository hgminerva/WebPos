using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstUnit
    {
        [Key]
        public Int32 Id { get; set; }
        public String Unit { get; set; }
    }
}