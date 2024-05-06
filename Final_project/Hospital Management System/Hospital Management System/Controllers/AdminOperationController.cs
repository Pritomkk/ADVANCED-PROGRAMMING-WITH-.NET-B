using BLL.Admin_Auth_Service;
using BLL.Admin_Operation_service;
using BLL.DTOS;
using Hospital_Management_System.Check_Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Hospital_Management_System.Controllers
{
    public class AdminOperationController : ApiController
    {
        [LogInCheck]
        [HttpPost]
        [Route("api/assignDoctor/{Dep_Id}")]
        public HttpResponseMessage Add_Doctor(int Dep_Id,DoctorDTO obj)
        {
            try
            {
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
                }
                string token = authHeader.Replace("Bearer ", "");
                var data = DoctorService.AddByAdmin(Dep_Id,token,obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [LogInCheck]
        [HttpPost]
        [Route("api/CreateDepartment")]
        public HttpResponseMessage CreateDepartmentBYAdmin(DepartmentDTO CreateDepDto)
        {
            var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader))
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
            }

            string token = authHeader.Replace("Bearer ", "");
            var DepInfo = DepartmentService.AddByAdmin(token,CreateDepDto);

            if (DepInfo != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, DepInfo);
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, "Admin information not found or invalid token.");
            }
        }

        [HttpGet]
        [Route("api/SearchDoctor/{doctorId}")]
        public HttpResponseMessage searchDoctor(int doctorId)
        {
            
            var docInfo = DoctorService.Search(doctorId);

            if (docInfo != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, docInfo);
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, "Not found the Doctor");
            }
        }


        [HttpDelete]
        [Route("api/deleteDoctorInfo/{doctorId}")]
        public HttpResponseMessage deletedoctorInfo(int doctorId)
        {

            var doctorInfo = DoctorService.Delete(doctorId);

            if (doctorInfo)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted successfully" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token not found or already expired" });
            }
        
               
        }











    }
}
