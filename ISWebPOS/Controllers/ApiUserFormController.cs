using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiUserFormController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST UserForm
        // ===========
        [Route("api/userForm/list")]
        public List<Models.MstUserForm> Get()
        {
            var userForms = from d in db.MstUserForms
                        select new Models.MstUserForm
                        {
                            Id = d.Id,
                            FormId = d.FormId,
                            UserId = d.UserId,
                            CanDelete = d.CanDelete,
                            CanAdd = d.CanAdd,
                            CanLock = d.CanLock,
                            CanUnlock = d.CanUnlock,
                            CanPrint = d.CanPrint,
                            CanPreview = d.CanPreview,
                            CanEdit = d.CanEdit,
                            CanTender = d.CanTender,
                            CanDiscount = d.CanDiscount,
                            CanView = d.CanView,
                            CanSplit = d.CanSplit,
                            CanCancel = d.CanCancel,
                            CanReturn = d.CanReturn
                        };
            return userForms.ToList();
        }

        // ===========
        // ADD UserForm
        // ===========
        [Route("api/userForm/add")]
        public int Post(Models.MstUserForm userForm)
        {
            try
            {
              

                Data.MstUserForm newUserForm = new Data.MstUserForm();

                newUserForm.FormId = userForm.FormId;
                newUserForm.UserId = userForm.UserId; 
                newUserForm.CanDelete = userForm.CanDelete;
                newUserForm.CanAdd = userForm.CanAdd;
                newUserForm.CanLock = userForm.CanLock;
                newUserForm.CanUnlock = userForm.CanUnlock;
                newUserForm.CanPrint = userForm.CanPrint;
                newUserForm.CanPreview = userForm.CanPreview;
                newUserForm.CanEdit = userForm.CanEdit;
                newUserForm.CanTender = userForm.CanTender;
                newUserForm.CanDiscount = userForm.CanDiscount;
                newUserForm.CanView = userForm.CanView;
                newUserForm.CanSplit = userForm.CanSplit;
                newUserForm.CanCancel = userForm.CanCancel;
                newUserForm.CanReturn = userForm.CanReturn;


                db.MstUserForms.InsertOnSubmit(newUserForm);
                db.SubmitChanges();

                return newUserForm.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE UserForm
        // ==============
        [Route("api/userForm/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstUserForm userForm)
        {
            try
            {

                var userFormId = Convert.ToInt32(id);
                var userForms = from d in db.MstUserForms where d.Id == userFormId select d;

                if (userForms.Any())
                {
                    var updateUserForm = userForms.FirstOrDefault();

                    updateUserForm.FormId = userForm.FormId;
                    updateUserForm.UserId = userForm.UserId;
                    updateUserForm.CanDelete = userForm.CanDelete;
                    updateUserForm.CanAdd = userForm.CanAdd;
                    updateUserForm.CanLock = userForm.CanLock;
                    updateUserForm.CanUnlock = userForm.CanUnlock;
                    updateUserForm.CanPrint = userForm.CanPrint;
                    updateUserForm.CanPreview = userForm.CanPreview;
                    updateUserForm.CanEdit = userForm.CanEdit;
                    updateUserForm.CanTender = userForm.CanTender;
                    updateUserForm.CanDiscount = userForm.CanDiscount;
                    updateUserForm.CanView = userForm.CanView;
                    updateUserForm.CanSplit = userForm.CanSplit;
                    updateUserForm.CanCancel = userForm.CanCancel;
                    updateUserForm.CanReturn = userForm.CanReturn;

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
        // DELETE UserForm
        // ==============
        [Route("api/userForm/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var userFormId = Convert.ToInt32(id);
                var userForms = from d in db.MstUserForms where d.Id == userFormId select d;

                if (userForms.Any())
                {
                    db.MstUserForms.DeleteOnSubmit(userForms.First());
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