using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace ISWebPOS.Controllers
{
    public class ApiFormController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();

        // ===========
        // LIST Form
        // ===========
        [Route("api/form/list")]
        public List<Models.SysForm> Get()
        {
            var isLocked = true;
            var Form = from d in db.SysForms
                              select new Models.SysForm
                              {
                                  Id = d.Id,
                                  Form = d.Form,
                                  FormDescription = d.FormDescription
                              };
            return Form.ToList();
        }

        // ========
        // ADD Form
        // ========
        [Route("api/form/add")]
        public int Post(Models.SysForm form)
        {
            try
            {
                Data.SysForm newForm= new Data.SysForm();

                //
                newForm.Form = form.Form;
                newForm.FormDescription = form.FormDescription;
                //

                db.SysForms.InsertOnSubmit(newForm);
                db.SubmitChanges();

                return newForm.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ===========
        // UPDATE Form
        // ===========
        [Route("api/form/update/{id}")]
        public HttpResponseMessage Put(String id, Models.SysForm form)
        {
            try
            {

                var FormId = Convert.ToInt32(id);
                var Form = from d in db.SysForms where d.Id == FormId select d;

                if (Form.Any())
                {
                    var updateForm = Form.FirstOrDefault();

                    //
                    updateForm.Form = form.Form;
                    updateForm.FormDescription = form.FormDescription;
                    //

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

        // ===========
        // DELETE Form
        // ===========
        [Route("api/form/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var FormId = Convert.ToInt32(id);
                var Form = from d in db.SysForms where d.Id == FormId select d;

                if (Form.Any())
                {
                    db.SysForms.DeleteOnSubmit(Form.First());
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