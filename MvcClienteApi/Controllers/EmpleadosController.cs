using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcClienteApi.Filters;
using MvcClienteApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApi.Controllers
{
    public class EmpleadosController : Controller
    {
        ServiceEmpleados ApiService;

        public EmpleadosController(ServiceEmpleados apiservice)
        {
            this.ApiService = apiservice;
        }

        [EmpleadoAuthorize]
        public async Task<IActionResult> PerfilEmpleado()
        {
            String token = HttpContext.Session.GetString("TOKEN");
            return View(await this.ApiService.GetPerfil(token));
        }

        [EmpleadoAuthorize]
        public async Task<IActionResult> Subordinados()
        {
            String token = HttpContext.Session.GetString("TOKEN");
            return View(await this.ApiService.GetSubordinados(token));
        }
    }
}
