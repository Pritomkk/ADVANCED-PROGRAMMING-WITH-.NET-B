using BLL.Admin_Auth_Service;
using BLL.DTOS;
using Hospital_Management_System.Check_Auth;
using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Hospital_Management_System.Controllers
{
    public class AdminAuthController : ApiController
    {
      

            [HttpPost]
            [Route("api/login/Admin")]
            public HttpResponseMessage Login(LoginModel login)
            {
                try
                {
                    var loginResult = AuthService.LogInAuthenticate(login.email, login.password);
                    if (loginResult != null)
                    {
                      
                        return Request.CreateResponse(HttpStatusCode.OK, new { loginResult });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User Not Found" });
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
                }
            }

        [LogInCheck]
        [HttpPut]
        [Route("api/UpdateAdmin")]
        public HttpResponseMessage UpdateAdmin(AdminDTO updatedAdmin)
        {
            try
            {
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (!string.IsNullOrEmpty(authHeader))
                {
                    string tokenKey = authHeader.Replace("Bearer ", "");
                    var updatedAdminDTO = AuthService.Update2(tokenKey, updatedAdmin);
                    if (updatedAdminDTO == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Admin Profile Update Sucefully"});
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Admin email not available" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
            [Route("api/SignUp/Admin")]
            public HttpResponseMessage SignUp(AdminDTO obj)
            {
                try
                {
                    var data = AdminSignUpService.SignUp(obj);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
        [LogInCheck]
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
               
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (!string.IsNullOrEmpty(authHeader))
                {
                 
                    string token = authHeader.Replace("Bearer ", "");

                    var success = AuthService.Logout(token);
                    if (success)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Logged out successfully" });
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

