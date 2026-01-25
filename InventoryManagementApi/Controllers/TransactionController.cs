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
    [RoutePrefix("Api/Transaction")]
    public class TransactionController : ApiController
    {
        [Logged]
        [Role("admin", "staff")]
        [HttpGet]
        [Route("All")]
        public HttpResponseMessage GetAllTransaction()
        {
            try
            {
                var data = TransactionService.GetAll();
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
        [Route("{id}")]
        public HttpResponseMessage GetTransaction(int id)
        {
            try
            {
                var data = TransactionService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Logged]
        [Role("staff")]
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateTransaction(TransactionDTO t)
        {
            try
            {
                var data = TransactionService.Create(t);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Logged]
        [Role("admin")]
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteTransaction(int id)
        {
            try
            {
                var data = TransactionService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Logged]
        [Role("staff")]
        [HttpPut]
        [Route("Update/{id}")]
        public HttpResponseMessage UpdateTransaction(int id, TransactionDTO tran)
        {
            try
            {
                tran.Id = id;
                var data = TransactionService.Update(tran);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Logged]
        [Role("admin", "staff")]
        [HttpGet]
        [Route("User/{username}")]
        public HttpResponseMessage GetByUser(string username)
        {
            try
            {
                var data = TransactionService.GetByUser(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Logged]
        [Role("admin", "staff")]
        [HttpGet]
        [Route("Product/{id}")]
        public HttpResponseMessage GetByProduct(int id)
        {
            try
            {
                var data = TransactionService.GetByProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Logged]
        [Role("admin", "staff")]
        [HttpGet]
        [Route("Type/{type}")]
        public HttpResponseMessage GetByType(string type)
        {
            try
            {
                var data = TransactionService.GetByType(type);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
