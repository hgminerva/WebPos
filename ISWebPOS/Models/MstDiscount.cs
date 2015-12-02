using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstDiscount
    {
        [Key]
        public Int32 Id { get; set; }
        public String Discount { get; set; }
        public Decimal DiscountRate { get; set; }
        public Boolean IsVatExempt { get; set; }
        public Boolean IsDateScheduled { get; set; }
        public String DateStart { get; set; }
        public String DateEnd { get; set; }
        public Boolean IsTimeScheduled { get; set; }
        public String TimeStart { get; set; }
        public String TimeEnd { get; set; }
        public Boolean IsDayScheduled { get; set; }
        public Boolean DayMon { get; set; }
        public Boolean DayTue { get; set; }
        public Boolean DayWed { get; set; }
        public Boolean DayThu { get; set; }
        public Boolean DayFri { get; set; }
        public Boolean DaySat { get; set; }
        public Boolean DaySun { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public String UpdateDateTime { get; set; }
        public Boolean IsLocked { get; set; }
    }
}