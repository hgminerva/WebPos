using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class SysAuditTrail
    {
        public Int32 Id { get; set; }
        public Int32 UserId { get; set; }
        public DateTime AuditDate { get; set; }
        public String TableInformation { get; set; }
        public String RecordInformation { get; set; }
        public String FormInformation { get; set; }
        public String ActionInformation { get; set; }
    }
}