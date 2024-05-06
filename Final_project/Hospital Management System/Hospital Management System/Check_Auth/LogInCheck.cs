using BLL.Admin_Auth_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Hospital_Management_System.Check_Auth
{
    public class LogInCheck: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token=actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response=
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new {Msg="No Token Find First Login In the System and Generate the token"});

            }
            else if(!AuthService.IsTokenValid(token.ToString()))
            {
                actionContext.Response =
                   actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "Supplied token is invalid" });


            }
            base.OnAuthorization(actionContext);
        }
                
    }
}