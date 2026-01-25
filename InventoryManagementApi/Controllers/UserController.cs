using BLL.DTOs;
using BLL.Services;
using InventoryManagementApi.AuthorizationFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementApi.Controllers
{
    [RoutePrefix("Api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Logged]
        [Role("admin", "staff")]
        [Route("All")]
        public HttpResponseMessage GetAllUser()
        {
            try
            {
                var data = UserService.GetAll();
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
        public HttpResponseMessage GetUser(string id)
        {
            try
            {
                var data = UserService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Logged]
        [Role("admin")]
        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateUser(UserDTO u)
        {
            try
            {
                var data = UserService.Create(u);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
