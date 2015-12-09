using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstTable
    {
        [Key]
        public Int32 Id { get; set; }
        public String TableCode { get; set; }
        public Int32 TableGroupId { get; set; }
        public Int32? TopLocation { get; set; }
        public Int32? LeftLocation { get; set; }


    }
}