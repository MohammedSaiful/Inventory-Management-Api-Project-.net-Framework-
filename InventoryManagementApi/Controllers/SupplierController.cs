using BLL.DTOs;
using BLL.Services;
using InventoryManagementApi.AuthorizationFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InventoryManagementApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]
    [RoutePrefix("Api/Supplier")]
    public class SupplierController : ApiController
    {
        //Show all suppliers
        [Logged]
        [Role("admin", "staff")]
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

        //search specific supplier by id
        [Logged]
        [Role("admin", "staff")]
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

        //will show products which supplied by specific supplier
        [Logged]
        [Role("admin", "staff")]
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

        // will create new supplier
        [Logged]
        [Role("admin")]
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

        //Delete specific supplier
        [Logged]
        [Role("admin")]
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

        //update specific supplier information
        [Logged]
        [Role("admin")]
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
