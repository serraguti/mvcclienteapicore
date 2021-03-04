using Microsoft.AspNetCore.Mvc;
using MvcClienteApi.Services;
using NuGetDoctoresModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApi.Controllers
{
    public class DoctoresController : Controller
    {
        ServiceDoctores ServiceApi;

        public DoctoresController(ServiceDoctores serviceapi)
        {
            this.ServiceApi = serviceapi;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.ServiceApi.GetDoctoresAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(int incremento, int hospital)
        {
            await this.ServiceApi.IncrementarSalariosAsync(incremento, hospital);
            return View(await this.ServiceApi.GetDoctoresAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.ServiceApi.GetDoctorAsync(id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await this.ServiceApi.GetDoctorAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            await this.ServiceApi.UpdateDoctorAsync(doctor.IdDoctor
                , doctor.Apellido, doctor.Especialidad, doctor.Hospital, doctor.Salario);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            await this.ServiceApi.InsertDoctorAsync(doctor.IdDoctor, doctor.Apellido
                , doctor.Especialidad, doctor.Hospital, doctor.Salario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.ServiceApi.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
