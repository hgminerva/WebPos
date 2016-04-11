using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISWebPOS
{
    public class NoCacheAttribute : ActionFilterAttribute
    {
         public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext == null) throw new ArgumentNullException("filterContext");
 
            var cache = GetCache(filterContext);
 
            cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            cache.SetValidUntilExpires(false);
            cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            cache.SetCacheability(HttpCacheability.NoCache);
            cache.SetNoStore();
 
            base.OnResultExecuting(filterContext);
        }
 
        /// <summary>
        /// Get the reponse cache
        /// </summary>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        protected virtual HttpCachePolicyBase GetCache(ResultExecutingContext filterContext)
        {
            return filterContext.HttpContext.Response.Cache;
        }
     }
}