using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiLastItemCodeController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // RETURN ITEM CODE
        // ===========
        [Route("api/item/lastitemcode")]
        public List<Models.MstItem> Get()
        {
            var item = from d in db.MstItems
                       select new Models.MstItem
                       {
                           ItemCode = d.ItemCode
                       };
            return item.ToList();
        }   
    }
}
