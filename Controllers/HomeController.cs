using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using PortalWebCliente.Models;

namespace PortalWebCliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult LogIn(int estadoUsuario = 0, int estadoContraseña = 0, string antiguoUsuario = "")
        {
            ViewBag.estadoUsuario = estadoUsuario;
            ViewBag.estadoContraseña = estadoContraseña;
            ViewBag.antiguoUsuario = antiguoUsuario;
            return View();
        }
        [HttpPost]
        public IActionResult Index(PersonaModel persona)
        {



            if (persona.userName != null)
            {
                if (persona.contraseña != null)
                {
                    SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
                    {
                        DataSource = "deltaserver.database.windows.net",
                        InitialCatalog = "deltadb",
                        UserID = "deltasa",
                        Password = "Delta123#"
                    };
                    SqlConnection cnn = new SqlConnection(sConnB.ConnectionString);
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM usuario", cnn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    int c = 0;
                    while (dr.Read())
                    {
                        c++;
                        if (persona.userName.Equals(dr["nombre"].ToString()))
                        {
                            if (persona.contraseña.Equals(dr["contraseña"].ToString()))
                            {
                                cnn.Close();
                                return View(persona);
                            }
                            else
                            {
                                cnn.Close();
                                return RedirectToAction("LogIn", "Home", new { @estadoContraseña=1, @antiguoUsuario = persona.userName });
                            }
                        }
                    }
                    cnn.Close();
                    return RedirectToAction("LogIn", "Home", new { @estadoUsuario=1, @antiguoUsuario = persona.userName });
                }
                else
                {
                    return RedirectToAction("LogIn", "Home", new { @estadoContraseña= 2 ,@antiguoUsuario=persona.userName});
                }
            }
            else
            {
                if (persona.contraseña == null)
                {
                    return RedirectToAction("LogIn", "Home", new { @estadoUsuario = 2, @estadoContraseña =2});
                }
                return RedirectToAction("LogIn", "Home", new { @estadoUsuario = 2 });
            }

            // respuesta con valores enteros para validar del lado del cliente la peticion // modificar el metodo de ser posible
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
