using BLL.Services;
using InventoryManagementApi.AuthorizationFilter;
using InventoryManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;

namespace InventoryManagementApi.Controllers
{
    // [RoutePrefix("Api")]
    [EnableCors("*","*","*")]
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
                    return Request.CreateResponse(HttpStatusCode.OK, res); //Login Successfully
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "Invalid Credentials" });
                //return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User Not Found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Msg = ex.Message});
            }
        }

        
        [HttpPost]
        [Logged]
        [Route("Api/Token/Refresh")]
        public HttpResponseMessage Refresh(string refreshToken)
        {
            try
            {
                var res = AuthenService.RefreshToken(refreshToken);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "Session expired. Please login again." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new{Msg= ex.Message});
            }
        }

        
        [HttpPost]
        [Logged]
        [Route("Api/Logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthenService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message});
            }
        }



    }
}
