using BLL.Admin_Auth_Service;
using BLL.DTOS;
using Hospital_Management_System.Check_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hospital_Management_System.Controllers
{
    public class AdminCrudController : ApiController
    {
        [LogInCheck]
        [HttpGet]
        [Route("api/GetAdmin")]
        public HttpResponseMessage GetAdmin()
        {
            var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader))
            { 
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
            }

            string token = authHeader.Replace("Bearer ", "");

        
            var adminInfo = AdminCrudService.Get(token);

            if (adminInfo != null)
            {
              
                return Request.CreateResponse(HttpStatusCode.OK, adminInfo);
            }
            else
            {
               
                return Request.CreateResponse(HttpStatusCode.NotFound, "Admin information not found or invalid token.");
            }
        }


        [LogInCheck]
        [HttpDelete]
        [Route("api/DeletAdmin")]
        public HttpResponseMessage DeleteAdmin()
        {
            try
            {

                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (!string.IsNullOrEmpty(authHeader))
                {

                    string token = authHeader.Replace("Bearer ", "");

                    var success = AdminCrudService.Delete(token);
                    if (success)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted successfully" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token not found or already expired" });
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Authorization header not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }



    }
}
