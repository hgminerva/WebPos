using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace easyfis.Models
{
    public class MstCustomer
    {
        [Key]
        public Int32 Id { get; set; }
        public String Customer { get; set; }
        public String Address { get; set; }
        public String ContactPerson { get; set; }
        public String ContactNumber { get; set; }
        public Double CreditLimit { get; set; }
        public Int32 TermId { get; set; }
        public String TIN { get; set; }
        public Boolean WithReward { get; set; }
        public String RewardNumber { get; set; }
        public Double RewardConversion { get; set; }
        public Int32 AccountId { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Boolean IsLocked { get; set; }
        public String DefaultPriceDescription { get; set; }
    }
}