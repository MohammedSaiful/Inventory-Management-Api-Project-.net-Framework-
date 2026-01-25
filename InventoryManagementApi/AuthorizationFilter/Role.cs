using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InventoryManagementApi.AuthorizationFilter
{
    public class Role: AuthorizationFilterAttribute
    {
        private readonly string[] roles;

        public Role(params string[] roles)
        {
            this.roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If Logged filter already failed, don't do anything
            if (actionContext.Response != null) return;

            var principal = System.Web.HttpContext.Current.User as ClaimsPrincipal;

            // JWT Claims often use this specific URL for the role claim
            var userRole = principal?.FindFirst(ClaimTypes.Role)?.Value
                           ?? principal?.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

            if (principal == null || string.IsNullOrEmpty(userRole) || !roles.Contains(userRole))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden,
                    new { Msg = "Access Denied: Your role (" + (userRole ?? "None") + ") is not authorized." });
            }

        }


        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    var tokenkey = actionContext.Request.Headers.Authorization?.ToString();

        //    var token = DataAccessFactory.TokenData().Get(tokenkey);
        //    if (!roles.Contains(token.UserType))
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden,
        //            new {Msg = "Access Denied for Update, Delete and Create"});
        //    }
        //    base.OnAuthorization(actionContext);
        //}
    }
}