using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CleevioApp.Filters
{
    public class InvoicesAuthorizeAttribute
        :AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            if(authHeader != null)
            {
                if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
                {
                    var rawCredentials = authHeader.Parameter;
                    var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(rawCredentials));
                    var split = credentials.Split(':');
                    var username = split[0];
                    var password = split[1];

                    if (Services.UserSecurity.Login(username,password))
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                        return;
                    }
                    else
                    {
                        actionContext.Response =
                            actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
            }
            else
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }


        }
    }
}