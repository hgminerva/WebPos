using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstUser
    {
        [Key]
        public Int32 Id { get; set; }
        public String UserName { get; set; }
        public String Password{get; set;}
        public String FullName { get; set; }
        public String UserCardNumber { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Boolean IsLocked { get; set; }

    }
}