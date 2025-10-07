using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementApi.Controllers
{
    [RoutePrefix("Api/Supplier")]
    public class SupplierController : ApiController
    {
        [HttpGet]
        [Route("All")]
        public HttpResponseMessage GetAllSupplier()
        {
            try
            {
                var data = SupplierService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex)
            { 
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetSupplier(int id)
        {
            try
            {
                var data = SupplierService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("{id}/Products")]
        public HttpResponseMessage SupplierProduct(int id)
        {
            try
            {
                var data = SupplierService.GetWithProducts(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateSupplier(SupplierDTO s)
        {
            try
            {
                var data = SupplierService.Create(s);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteSupplier(int id)
        {
            try
            {
                var data = SupplierService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public HttpResponseMessage UpdateSupplier(int id, SupplierDTO sup)
        {
            try
            {
                sup.Id = id;
                var data = SupplierService.Update(sup);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
