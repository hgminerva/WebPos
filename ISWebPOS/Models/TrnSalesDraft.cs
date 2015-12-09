using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class TrnSalesDraft
    {
        [Key]
        public Int32 Id { get; set; }
        public String DocRef { get; set; }
        public String DocDate { get; set; }
        public String ItemCode { get; set; }
        public Int32 ItemId { get; set; }
        public Decimal Price { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Amount { get; set; }
        public String CustomerCode { get; set; }
        public String Customer { get; set; }
        public String ContactPerson { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String MobilePhoneNumber { get; set; }


    
    }
}