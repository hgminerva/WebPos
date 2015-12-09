using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiDiscountController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Discount
        // ===========
        [Route("api/discount/list")]
        public List<Models.MstDiscount> Get()
        {
            var isLocked = true;

            var discount = from d in db.MstDiscounts
                           select new Models.MstDiscount
                           {
                               Id = d.Id,
                               Discount = d.Discount,
                               DiscountRate = d.DiscountRate,
                               IsVatExempt = d.IsVatExempt,
                               IsDateScheduled = d.IsDateScheduled,
                               DateStart = Convert.ToString(d.DateStart),
                               DateEnd = Convert.ToString(d.DateEnd),
                               IsTimeScheduled = d.IsTimeScheduled,
                               TimeStart = Convert.ToString(d.TimeStart),
                               TimeEnd = Convert.ToString(d.TimeEnd),
                               IsDayScheduled = d.IsDayScheduled,
                               DayMon = d.DayMon,
                               DayTue = d.DayTue,
                               DayWed = d.DayWed,
                               DayThu = d.DayThu,
                               DayFri = d.DayFri,
                               DaySat = d.DaySat,
                               DaySun = d.DaySun,

                               EntryUserId = d.EntryUserId,
                               EntryDateTime = Convert.ToString(d.EntryDateTime),
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = Convert.ToString(d.UpdateDateTime),
                               IsLocked = isLocked
                           };
            return discount.ToList();
        }

        // ===========
        // ADD Discount
        // ===========
        [Route("api/discount/add")]
        public int Post(Models.MstDiscount discount)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstDiscount newDiscount = new Data.MstDiscount();

                newDiscount.Id = discount.Id;
                newDiscount.Discount = discount.Discount;
                newDiscount.DiscountRate = discount.DiscountRate;
                newDiscount.IsVatExempt = discount.IsVatExempt;
                newDiscount.IsDateScheduled = discount.IsDateScheduled;
                newDiscount.DateStart = Convert.ToDateTime(discount.DateStart);
                newDiscount.DateEnd = Convert.ToDateTime(discount.DateEnd);
                newDiscount.IsTimeScheduled = discount.IsTimeScheduled;
                newDiscount.TimeStart = Convert.ToDateTime(discount.TimeStart);
                newDiscount.TimeEnd = Convert.ToDateTime(discount.TimeEnd);
                newDiscount.IsDayScheduled = discount.IsDayScheduled;
                newDiscount.DayMon = discount.DayMon;
                newDiscount.DayTue = discount.DayTue;
                newDiscount.DayWed = discount.DayWed;
                newDiscount.DayThu = discount.DayThu;
                newDiscount.DayFri = discount.DayFri;
                newDiscount.DaySat = discount.DaySat;
                newDiscount.DaySun = discount.DaySun;

                newDiscount.EntryUserId = mstUserId;
                newDiscount.EntryDateTime = date;
                newDiscount.UpdateUserId = mstUserId;
                newDiscount.UpdateDateTime = date;
                newDiscount.IsLocked = isLocked;

                db.MstDiscounts.InsertOnSubmit(newDiscount);
                db.SubmitChanges();

                return newDiscount.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Discount
        // ==============
        [Route("api/discount/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstDiscount discount)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                var discountId = Convert.ToInt32(id);
                var discounts = from d in db.MstDiscounts where d.Id == discountId select d;

                if (discounts.Any())
                {
                    var updateDiscount= discounts.FirstOrDefault();

                    updateDiscount.Id = discount.Id;
                    updateDiscount.Discount = discount.Discount;
                    updateDiscount.DiscountRate = discount.DiscountRate;
                    updateDiscount.IsVatExempt = discount.IsVatExempt;
                    updateDiscount.IsDateScheduled = discount.IsDateScheduled;
                    updateDiscount.DateStart = Convert.ToDateTime(discount.DateStart);
                    updateDiscount.DateEnd = Convert.ToDateTime(discount.DateEnd);
                    updateDiscount.IsTimeScheduled = discount.IsTimeScheduled;
                    updateDiscount.TimeStart = Convert.ToDateTime(discount.TimeStart);
                    updateDiscount.TimeEnd = Convert.ToDateTime(discount.TimeEnd);
                    updateDiscount.IsDayScheduled = discount.IsDayScheduled;
                    updateDiscount.DayMon = discount.DayMon;
                    updateDiscount.DayTue = discount.DayTue;
                    updateDiscount.DayWed = discount.DayWed;
                    updateDiscount.DayThu = discount.DayThu;
                    updateDiscount.DayFri = discount.DayFri;
                    updateDiscount.DaySat = discount.DaySat;
                    updateDiscount.DaySun = discount.DaySun;

                    updateDiscount.UpdateUserId = mstUserId;
                    updateDiscount.UpdateDateTime = date;
                    updateDiscount.IsLocked = isLocked;

                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // ==============
        // DELETE Discount
        // ==============
        [Route("api/discount/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var discountId = Convert.ToInt32(id);
                var discounts = from d in db.MstDiscounts where d.Id == discountId select d;

                if (discounts.Any())
                {
                    db.MstDiscounts.DeleteOnSubmit(discounts.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
