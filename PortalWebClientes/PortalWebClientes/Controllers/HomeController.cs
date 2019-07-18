using System.Collections.Generic;
using System.Web.Mvc;

namespace PortalWebClientes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult About(string email)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.email = email;
            List<User> listaDeUsuarios = new List<User>()
            {
                new User{email=email,name="Jorge"},
                new User{email="OtroEmail",name="Jorge2"}
            };
            return View(listaDeUsuarios);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }

    }
}