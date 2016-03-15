using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
namespace ISWebPOS.Controllers
{
    public class ApiSupplierController : ApiController
    {
        private Data.webposDataContext db = new Data.webposDataContext();


        //============
        // GET SUPPLIER
        //============
        [Route("api/supplier/search/{id}")]
        public List<Models.MstSupplier> GetSupper(String id)
        {
            var Id = Convert.ToInt32(id);
            var suppliers = from d in db.MstSuppliers
                            where d.Id == Id
                            select new Models.MstSupplier
                            {
                                Id = d.Id,
                                Supplier = d.Supplier,
                                Address = d.Address,
                                TelephoneNumber = d.TelephoneNumber,
                                CellphoneNumber = d.CellphoneNumber,
                                FaxNumber = d.FaxNumber,
                                TermId = d.TermId,
                                TIN = d.TIN,
                                AccountId = d.AccountId,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime,
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime,
                                IsLocked = true

                            };
            return suppliers.ToList();
        }
        // ===========
        // LIST Supplier
        // ===========
        [Route("api/supplier/list")]
        public List<Models.MstSupplier> Get()
        {
            var isLocked = true;
            var suppliers = from d in db.MstSuppliers
                           select new Models.MstSupplier
                           {
                               Id = d.Id,
                               Supplier = d.Supplier,
                               Address = d.Address,
                               TelephoneNumber = d.TelephoneNumber,
                               CellphoneNumber = d.CellphoneNumber,
                               FaxNumber = d.FaxNumber,
                               TermId = d.TermId,
                               TIN = d.TIN,
                               AccountId = d.AccountId,
                               EntryUserId = d.EntryUserId,
                               EntryDateTime = d.EntryDateTime,
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = d.UpdateDateTime,
                               IsLocked = isLocked

                           };
            return suppliers.ToList();
        }

        // ===========
        // ADD Supplier
        // ===========
        [Route("api/supplier/add")]
        public int Post(Models.MstSupplier supplier)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;
                Data.MstSupplier newSupplier = new Data.MstSupplier();

                newSupplier.Id = supplier.Id;
                newSupplier.Supplier = supplier.Supplier;
                newSupplier.Address = supplier.Address;
                newSupplier.TelephoneNumber = supplier.TelephoneNumber;
                newSupplier.CellphoneNumber = supplier.CellphoneNumber;
                newSupplier.FaxNumber = supplier.FaxNumber;
                newSupplier.TermId = supplier.TermId;
                newSupplier.TIN = supplier.TIN;
                newSupplier.AccountId = supplier.AccountId;
                newSupplier.EntryUserId = 129;//mstUserId;
                newSupplier.EntryDateTime = date;
                newSupplier.UpdateUserId = 129;// mstUserId;
                newSupplier.UpdateDateTime = date;
                newSupplier.IsLocked = isLocked;

                db.MstSuppliers.InsertOnSubmit(newSupplier);
                db.SubmitChanges();

                return newSupplier.Id;
            }
            catch
            {
                return 0;
            }
        }

        // ==============
        // UPDATE Supplier
        // ==============
        [Route("api/supplier/update/{id}")]
        public HttpResponseMessage Put(String id, Models.MstSupplier supplier)
        {
            try
            {
                var isLocked = true;
                var identityUserId = User.Identity.GetUserId();
                var mstUserId = (from d in db.MstUsers where "" + d.Id == identityUserId select d.Id).SingleOrDefault();
                var date = DateTime.Now;
                var Id = Convert.ToInt32(id);
                var suppliers = from d in db.MstSuppliers where d.Id == Id select d;

                if (suppliers.Any())
                {
                    var updateSupplier = suppliers.FirstOrDefault();

                    updateSupplier.Supplier = supplier.Supplier;
                    updateSupplier.Address = supplier.Address;
                    updateSupplier.TelephoneNumber = supplier.TelephoneNumber;
                    updateSupplier.CellphoneNumber = supplier.CellphoneNumber;
                    updateSupplier.FaxNumber = supplier.FaxNumber;
                    updateSupplier.TermId = supplier.TermId;
                    updateSupplier.TIN = supplier.TIN;
                    updateSupplier.AccountId = supplier.AccountId;
                    updateSupplier.EntryUserId = 129;// mstUserId;
                    updateSupplier.EntryDateTime = date;
                    updateSupplier.UpdateUserId = 129;// mstUserId;
                    updateSupplier.UpdateDateTime = date;
                    updateSupplier.IsLocked = isLocked;


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
        // DELETE Supplier
        // ==============
        [Route("api/supplier/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var supplierId = Convert.ToInt32(id);
                var suppliers = from d in db.MstSuppliers where d.Id == supplierId select d;

                if (suppliers.Any())
                {
                    db.MstSuppliers.DeleteOnSubmit(suppliers.First());
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