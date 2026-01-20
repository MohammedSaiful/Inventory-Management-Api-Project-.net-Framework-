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
    [RoutePrefix("Api/Product")]
    public class ProductController : ApiController
    {
        [Logged]
        [Role("admin", "staff")]
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
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [Role("admin", "staff")]
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
                return Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    new {Msg = ex.Message});
            }
        }

        [Logged]
        [Role("admin")]
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
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [Role("admin")]
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
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [Role("admin")]
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
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [Role("admin", "staff")]
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

        [Logged]
        [Role("admin", "staff")]
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
