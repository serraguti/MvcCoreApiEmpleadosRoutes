﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreApiEmpleadosRoutes.Models;
using MvcCoreApiEmpleadosRoutes.Services;

namespace MvcCoreApiEmpleadosRoutes.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> EmpleadosOficio()
        {
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            List<string> oficios = await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> EmpleadosOficio(string oficio)
        {
            List<Empleado> empleados = await this.service.GetEmpleadosOficioAsync(oficio);
            List<string> oficios = await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado empleado = await this.service.FindEmpleadoAsync(id);
            return View(empleado);
        }
    }
}
