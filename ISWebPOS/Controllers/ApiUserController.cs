using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiUserController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST User
        // ===========
        [Route("api/user/list")]
        public List<Models.MstUser> Get()
        {
            var isLocked = true;

            var users = from d in db.MstUsers
                           select new Models.MstUser
                           {
                               Id = d.Id,
                               UserName = d.UserName,
                               Password = d.Password,
                               FullName = d.FullName,
                               UserCardNumber = d.UserCardNumber,
                               EntryUserId = d.EntryUserId,
                               EntryDateTime = d.EntryDateTime,
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = d.UpdateDateTime,
                               IsLocked = d.IsLocked
                           };
            return users.ToList();
        }

        // ===========
        // ADD User
        // ===========
        [Route("api/user/add")]
        public int Post(Models.MstUser user)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;

                Data.MstUser newUser = new Data.MstUser();

                newUser.UserName = user.UserName;
                newUser.IsLocked = isLocked;
                newUser.Password = user.Password;
                newUser.FullName = user.FullName;
                newUser.UserCardNumber = user.UserCardNumber;
                newUser.EntryUserId = mstUserId;
                newUser.EntryDateTime = date;
                newUser.UpdateUserId = mstUserId;
                newUser.UpdateDateTime = date;



                db.MstUsers.InsertOnSubmit(newUser);
                db.SubmitChanges();

                return newUser.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE User
        // ==============
        [Route("api/user/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstUser user)
        {
            try
            {
                var isLocked = true;

                var userId = Convert.ToInt32(id);
                var users = from d in db.MstUsers where d.Id == userId select d;

                if (users.Any())
                {
                    var updateUser = users.FirstOrDefault();

                    updateUser.UserName = user.UserName;
                    updateUser.IsLocked = isLocked;
                    updateUser.Password = user.Password;
                    updateUser.FullName = user.FullName;
                    updateUser.UserCardNumber = user.UserCardNumber;
                    updateUser.UpdateUserId = user.UpdateUserId;
                    updateUser.UpdateDateTime = user.UpdateDateTime;

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
        // DELETE User
        // ==============
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var userId = Convert.ToInt32(id);
                var users = from d in db.MstUsers where d.Id == userId select d;

                if (users.Any())
                {
                    db.MstUsers.DeleteOnSubmit(users.First());
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