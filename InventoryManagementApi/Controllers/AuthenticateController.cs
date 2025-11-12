using BLL.Services;
using InventoryManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace InventoryManagementApi.Controllers
{
   // [RoutePrefix("Api")]
    public class AuthenticateController : ApiController
    {
        [HttpPost]
        [Route("Api/Login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var res = AuthenService.Authenticate(login.username, login.password);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User Not Found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Message = ex.Message});
            }
        }


    }
}
