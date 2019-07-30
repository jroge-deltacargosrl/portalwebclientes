using System.Collections.Generic;
using System.Web.Mvc;

namespace PortalWebClientes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            //VERIFICACION DE CREDENCIALES
            ViewBag.nombrePersona = "Jorge";
            return View();
        }
    }
}