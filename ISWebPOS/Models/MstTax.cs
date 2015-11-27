using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstTax
    {
        [Key]
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Tax { get; set; }
        public Double Rate { get; set; }
        public Int32 AccountId { get; set; }

    }
}