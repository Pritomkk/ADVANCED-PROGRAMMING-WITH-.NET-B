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
        public HttpResponseMessage Add_Doctor(int Dep_Id, DoctorDTO obj)
        {
            try
            {
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
                }
                string token = authHeader.Replace("Bearer ", "");
                var data = DoctorService.AddByAdmin(Dep_Id, token, obj);
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
           

            try
            {
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
                }

                string token = authHeader.Replace("Bearer ", "");
                var DepInfo = DepartmentService.AddByAdmin(token, CreateDepDto);

                if (DepInfo != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, DepInfo);
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound, "Admin information not found or invalid token.");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }





        }

        [HttpGet]
        [Route("api/SearchDoctor/{doctorId}")]
        public HttpResponseMessage searchDoctor(int doctorId)
        {


            try
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
            
              catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


        [HttpDelete]
        [Route("api/deleteDoctorInfo/{doctorId}")]
        public HttpResponseMessage deletedoctorInfo(int doctorId)
        { 

            try
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


              catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }


        }

        [LogInCheck]
        [HttpPost]
        [Route("api/AdmitPaitent")]
        public HttpResponseMessage AdmitPaitent(PaitentDTO obj)
        {
            var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader))
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
            }

            string token = authHeader.Replace("Bearer ", "");
            var AdmitPaitentInfo = PaitentService.AddByAdmin(token, obj);

            if (AdmitPaitentInfo != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, AdmitPaitentInfo);
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, "Admin information not found or invalid token.");
            }
        }

        [LogInCheck]
        [HttpPost]
        [Route("api/dischargePaitent/{PaitentID}")]
        public HttpResponseMessage dischargePaitent(int PaitentID, dischargePaitentDTO obj)
        {
            try
            {
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
                }
                string token = authHeader.Replace("Bearer ", "");
                var data = PaitentService.DischargePaitent(PaitentID, obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }



        [HttpGet]
        [Route("api/SearchPaitent/{PaitentId}")]
        public HttpResponseMessage searchPaitent(int PaitentId)
        {
   

            try
            {
                var Info = PaitentService.Search(PaitentId);

                if (Info != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, Info);
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found the paitent");
                }

            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }


        [HttpDelete]
        [Route("api/deletePaitentInfo/{paitentId}")]
        public HttpResponseMessage deletePaitentInfo(int paitentId)
        {

            var paitentInfo = PaitentService.Delete(paitentId);

            if (paitentInfo)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted successfully" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Paitent not found" });
            }


        }


        [LogInCheck]
        [HttpPost]
        [Route("api/Appionment/{patientId}/{doctorId}")]
        public HttpResponseMessage AppionmentDoctor(int patientId, int doctorId, AppionmentDTO appionmentDTO)
        {
            try
            {
                var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

                if (string.IsNullOrEmpty(authHeader))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
                }
                string token = authHeader.Replace("Bearer ", "");
                var data = AppionmentService.AppionmentDoctor(token,patientId,doctorId,appionmentDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }



        [HttpDelete]
        [Route("api/deleteAppionment/{AppionmentID}")]
        public HttpResponseMessage deleteAppionment(int AppionmentID)
        {

            var paitentInfo = AppionmentService.Delete(AppionmentID);

            if (paitentInfo)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted successfully" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Token not found or already expired" });
            }


        }


        [HttpGet]
        [Route("api/SearchAppionment/{AppionmentID}")]
        public HttpResponseMessage searchAppionment(int AppionmentID)
        {

            var docInfo = AppionmentService.Search(AppionmentID);

            if (docInfo != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, docInfo);
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, "Not found the paitent");
            }
        }




        [HttpGet]
        [Route("api/CheckdoctorAppionment/{doctorId}")]
        public HttpResponseMessage GetDoctorAppointments(int doctorId)
        {
            


            try
            {
                var appointmentService = new AppionmentService();

                var doctorAppointments = appointmentService.DoctorAppionment(doctorId);

                if (doctorAppointments.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, doctorAppointments);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }

            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/CancelAppointment/{patientId}")]
        public HttpResponseMessage CancelAppointment(int patientId, cancelAppionmentDTO obj)
        {
            try
            { 
                var canceledAppointmentDTO = AppionmentService.cancelAppionment(patientId, obj);

                if (canceledAppointmentDTO != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, canceledAppointmentDTO);
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to cancel appointment.");
                }
            }
            catch (Exception ex)
            {
         
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [LogInCheck] 
        [HttpPost]
        [Route("api/InventoryAdd")]
        public HttpResponseMessage AddInventory(InventoryDTO obj)
        {
            var authHeader = Request.Headers.GetValues("Authorization").FirstOrDefault();

            if (string.IsNullOrEmpty(authHeader))
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Authorization header is missing.");
            }

            string token = authHeader.Replace("Bearer ", "");

            try
            {
                var Inven_Info = InventoryService.AddInventory(token, obj);

                if (Inven_Info != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Added New Inventory");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Admin information not found or invalid token.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/allInventory")]
        public HttpResponseMessage AllInventory()
        {
            try
            {
                var inventoryService = new InventoryService();

                var inventoryInfo = inventoryService.AllInventoryinfo();

                if (inventoryInfo != null && inventoryInfo.Count > 0) 
                {
                    return Request.CreateResponse(HttpStatusCode.OK, inventoryInfo);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No inventory found.");
                }
            }
            catch (Exception ex)
            {
                

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }



        [HttpDelete]
        [Route("api/deleteInventory/{InventoryId}")]
        public HttpResponseMessage deleteInventoryInfo(int InventoryId)
        {

            var InvenInfo = InventoryService.Delete(InventoryId);

            if (InvenInfo)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted successfully" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Inventory Not found give Correct Id" });
            }


        }

        [HttpGet]
        [Route("api/BillingInfo/{InventoryId}")]
        public HttpResponseMessage BillingInfo(int InventoryId)
        {


            try
            {
                var InventoryInfo = InventoryService.BillingInfo(InventoryId);

                if (InventoryInfo != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, InventoryInfo);
                }
                else
                {

                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found ");
                }

            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }




    }
}
