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
    [RoutePrefix("Api/Product")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("All")]
        public HttpResponseMessage GetAllProduct()
        {
            try
            {
                var data = ProductService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetProduct(int id)
        {
            try
            {
                var data = ProductService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                var data = ProductService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateProduct(ProductDTO pro)
        {
            try
            {
                var data = ProductService.Create(pro);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public HttpResponseMessage UpdateProduct(int id, ProductDTO pro)
        {
            try
            {
                pro.Id = id;
                var data = ProductService.Update(pro);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/Transactions")]
        public HttpResponseMessage ProductTransactions(int id)
        {
            try
            {
                var data = ProductService.GetWithTransaction(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("{id}/Notifications")]
        public HttpResponseMessage ProductNotifications(int id)
        {
            try
            {
                var data = ProductService.GetWithNotification(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
