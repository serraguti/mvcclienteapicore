using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApi.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult PerfilEmpleados()
        {
            return View();
        }

        public IActionResult Subordinados()
        {
            return View();
        }
    }
}
