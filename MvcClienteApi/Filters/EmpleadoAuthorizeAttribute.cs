using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApi.Filters
{
    public class EmpleadoAuthorizeAttribute : AuthorizeAttribute,
        IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //SOLO QUEREMOS SABER SI EL EMPLEADO SE HA VALIDADO O NO 
            //PARA LLEVARLO A LOGIN
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated == false)
            {
                RouteValueDictionary rutalogin =
                    new RouteValueDictionary(new { 
                        controller= "Identity", action = "Login"
                    });
                context.Result = new RedirectToRouteResult(rutalogin);
            }
        }
    }
}
