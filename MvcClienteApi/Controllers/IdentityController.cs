using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcClienteApi.Models;
using MvcClienteApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcClienteApi.Controllers
{
    public class IdentityController : Controller
    {
        ServiceEmpleados ApiService;

        public IdentityController(ServiceEmpleados apiservice)
        {
            this.ApiService = apiservice;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(String username, String password)
        {
            String token = await
                this.ApiService.GetToken(username, password);
            if (token == null)
            {
                ViewData["MENSAJE"] = "Ususario/Password incorrectos";
                return View();
            }
            else
            {
                Empleado empleado = await this.ApiService.GetPerfil(token);
                ClaimsIdentity identity =
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme
                    , ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier
                    , empleado.IdEmpleado.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name
                    , empleado.Apellido));
                //SI DESEARAMOS VALIDAR POR ROLE (IsInRole)
                identity.AddClaim(new Claim(ClaimTypes.Role
                    , empleado.Oficio));
                ClaimsPrincipal principal =
                    new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                    , principal, new AuthenticationProperties
                    {
                        IsPersistent = true
                        , ExpiresUtc = DateTime.Now.AddMinutes(15)
                    });
                //PARA PODER TRABAJAR, NECESITAMOS ALMACENAR EL TOKEN
                //PARA QUE LOS CONTROLLERS PUEDAN REALIZAR PETICIONES
                //AL API
                HttpContext.Session.SetString("TOKEN", token);
                return RedirectToAction("PerfilEmpleado", "Empleados");
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            if (HttpContext.Session.GetString("TOKEN") != null)
            {
                HttpContext.Session.Remove("TOKEN");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
