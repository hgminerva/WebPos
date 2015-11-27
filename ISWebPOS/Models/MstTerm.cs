using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstTerm
    {
        [Key]
        public Int32 Id { get; set; }
        public String Term { get; set; }
        public Double NumberOfDays { get; set; }
    }
}