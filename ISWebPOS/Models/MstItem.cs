using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWebPOS.Models
{
    public class MstItem
    {
        [Key]
        public Int32 Id { get; set; }
        public String ItemCode { get; set; }
        public String BarCode { get; set; }
        public String ItemDescription { get; set; }
        public String Alias { get; set; }
        public String GenericName { get; set; }
        public String Catergory { get; set; }
        public Int32 SalesAccountId { get; set; }
        public Int32 AssetAccountId { get; set; }
        public Int32 CostAccountId { get; set; }
        public Int32 InTaxId { get; set; }
        public Int32 OutTaxId { get; set; }
        public Int32 UnitId { get; set; }
        public Int32 DefaultSupplierId { get; set; }
        public Double Cost { get; set; }
        public Double MarkUp { get; set; }
        public Double Price { get; set; }
        public String ImagePath { get; set; }
        public Double ReorderQuantity { get; set; }
        public Double OnhandQuantity { get; set; }
        public Boolean IsInventory { get; set; }
        public DateTime ExpiryDate { get; set; }
        public String LotNumber { get; set; }
        public String Remarks { get; set; }
        public Int32 EntryUserId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public Boolean isLocked { get; set; }
        public String DefaultKitchenReport { get; set; }
        public Boolean IsPackage { get; set; }
    }
}