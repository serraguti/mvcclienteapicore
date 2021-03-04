using Microsoft.AspNetCore.Mvc;
using MvcClienteApi.Models;
using MvcClienteApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApi.Controllers
{
    public class DepartamentosController : Controller
    {
        ServiceDepartamentos ServiceApi;

        public DepartamentosController(ServiceDepartamentos serviceapi)
        {
            this.ServiceApi = serviceapi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListDepartamentos()
        {
            return View(await this.ServiceApi.GetDepartamentosAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.ServiceApi.BuscarDepartamentoAsync(id));
        }

        public async Task<IActionResult> Edit (int id)
        {
            return View(await this.ServiceApi.BuscarDepartamentoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            await this.ServiceApi.UpdateDepartamentoAsync(dept.IdDepartamento
                , dept.Nombre, dept.Localidad);
            return RedirectToAction("ListDepartamentos");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.ServiceApi.InsertDepartamentoAsync(dept.IdDepartamento
                , dept.Nombre, dept.Localidad);
            return RedirectToAction("ListDepartamentos");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.ServiceApi.DeleteDepartamentoAsync(id);
            return RedirectToAction("ListDepartamentos");
        }

        public IActionResult ApiClienteAjax()
        {
            return View();
        }
    }
}
