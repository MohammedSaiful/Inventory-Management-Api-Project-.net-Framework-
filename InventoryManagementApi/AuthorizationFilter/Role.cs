using DAL;
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
    public class Role: AuthorizationFilterAttribute
    {
        private readonly string[] roles;

        public Role(params string[] roles)
        {
            this.roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var tokenkey = actionContext.Request.Headers.Authorization?.ToString();

            var token = DataAccessFactory.TokenData().Get(tokenkey);
            if (!roles.Contains(token.UserType))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden,
                    new {Msg = "Access Denied"});
            }
            base.OnAuthorization(actionContext);
        }
    }
}