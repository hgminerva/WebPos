using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstItemGroup
    {
        [Key]
        public Int32 Id { get; set; }
        public String ItemGroup { get; set; }
        public String ImagePath { get; set; }
        public String KitchenReport { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public String UpdateDateTime { get; set; }
        public Boolean IsLocked { get; set; }

    }
}