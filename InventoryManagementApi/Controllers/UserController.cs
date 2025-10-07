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
    [RoutePrefix("Api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
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

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateNotification(UserDTO u)
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
