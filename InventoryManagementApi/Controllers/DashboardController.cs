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
    [RoutePrefix("Api/Dashboard")]
    public class DashboardController : ApiController
    {
        [HttpGet]
        [Logged]
        [Route("Summary")]
        public HttpResponseMessage GetSummary()
        {
            try
            {
                var data = DashboardService.GetSummary();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //[Logged]
        //[Role("admin", "staff")]
        //[HttpGet]
        //[Route("TopSelling")]
        //public HttpResponseMessage GetTopSelling()
        //{
        //    try
        //    {
        //        var data = DashboardService.GetTop5Selling();
        //        return Request.CreateResponse(HttpStatusCode.OK, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
    }
}
