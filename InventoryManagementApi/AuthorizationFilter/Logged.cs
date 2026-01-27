using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InventoryManagementApi.AuthorizationFilter
{
    public class Logged: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization?.ToString();

            // Check if token exists
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new { Msg = "No token provided" });
                return;
            }

            // Validate JWT structure and Expiry
            var principal = JwtService.GetPrincipal(token);

            // Check Database (AuthenService.ValidateToken) to ensure user didn't Logout
            if (principal != null && AuthenService.ValidateToken(token))
            {
                System.Web.HttpContext.Current.User = principal;
                return;
            }

            // If reach here, the token is either expired or deleted in DB
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                new { Msg = "Invalid or Expired Session" });
        }


        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    var token = actionContext.Request.Headers.Authorization;
        //    if (token == null)
        //    {
        //        actionContext.Response = 
        //            actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized,
        //                new { Msg = "No token supplied" });
        //    }
        //    else if(!AuthenService.ValidateToken(token.ToString()))
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized,
        //            new { Msg = "Supplied token is invalid or expired" });
        //    }
        //    base.OnAuthorization(actionContext);
        //}
    }
}