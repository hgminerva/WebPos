using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiAccountController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Account
        // ===========
        [Route("api/account/list")]
        public List<Models.MstAccount> Get()
        {
            var accounts = from d in db.MstAccounts
                           select new Models.MstAccount
                           {
                               Id = d.Id,
                               Account = d.Account,
                               Code = d.Code,
                               AccountType = d.AccountType,
                               IsLocked = d.IsLocked
                           };
            return accounts.ToList();
        }

        // ===========
        // ADD Account
        // ===========
        [Route("api/account/add")]
        public int Post(Models.MstAccount account)
        {
            try
            {
                var isLocked = true;

                Data.MstAccount newAccount = new Data.MstAccount();

                newAccount.Account = account.Account;
                newAccount.IsLocked = isLocked;
                newAccount.Code = account.Code;
                newAccount.AccountType = account.AccountType;

                db.MstAccounts.InsertOnSubmit(newAccount);
                db.SubmitChanges();

                return newAccount.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Account
        // ==============
        [Route("api/account/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstAccount account)
        {
            try
            {
                var isLocked = true;

                var accountId = Convert.ToInt32(id);
                var accounts = from d in db.MstAccounts where d.Id == accountId select d;

                if (accounts.Any())
                {
                    var updateAccount = accounts.FirstOrDefault();

                    updateAccount.Account = account.Account;
                    updateAccount.IsLocked = isLocked;
                    updateAccount.Code = account.Code;
                    updateAccount.AccountType = account.AccountType;

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
        // DELETE Account
        // ==============
        [Route("api/account/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var accountId = Convert.ToInt32(id);
                var accounts = from d in db.MstAccounts where d.Id == accountId select d;

                if (accounts.Any())
                {
                    db.MstAccounts.DeleteOnSubmit(accounts.First());
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
