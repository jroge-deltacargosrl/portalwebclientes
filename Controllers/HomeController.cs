using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PortalWebCliente.Models;
using static PortalWebCliente.Utils.SessionExtensions;

namespace PortalWebCliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login(int estadoUsuario = 0, int estadoContraseña = 0, string antiguoUsuario = "")
        {
            ViewBag.estadoUsuario = estadoUsuario;
            ViewBag.estadoContraseña = estadoContraseña;
            ViewBag.antiguoUsuario = antiguoUsuario;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

