using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstAccount
    {
        [Key]
        public Int32 Id { get; set; }
        public String Code { get; set; }
        public String Account { get; set; }
        public Boolean IsLocked { get; set; }
        public String AccountType { get; set; }
    }
}