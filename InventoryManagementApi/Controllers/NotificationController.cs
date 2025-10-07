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
    public class NotificationController : ApiController
    {
        [HttpGet]
        [Route("All")]
        public HttpResponseMessage GetAllNotification()
        {
            try
            {
                var data = NotificationService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetNotifiation(int id)
        {
            try
            {
                var data = NotificationService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage CreateNotification(NotificationDTO n)
        {
            try
            {
                var data = NotificationService.Create(n);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteNotification(int id)
        {
            try
            {
                var data = NotificationService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
    }
}
