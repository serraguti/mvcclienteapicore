using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApiDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ApiClienteAjax()
        {
            return View();
        }

        public IActionResult ApiCrudServidor()
        {
            return View();
        }
    }
}
