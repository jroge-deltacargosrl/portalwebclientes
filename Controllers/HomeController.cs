using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using PortalWebCliente.Models;
using RestSharp;
using PortalWebCliente.Models.Infrastructure;

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
            int estadoUsuario = 0, estadoContraseña = 0;string antiguoUsuario = "";
            if (persona.userName != null)
            {
                if (persona.contraseña != null)
                {
                    string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
                    var responseRequest = new RequestAPI()
                        .addClient(new RestClient(urlRequest))
                        .addRequest(new RestRequest("operation/{idCustomer}", Method.GET))
                        .addHeader(new KeyValuePair<string, object>("Accept","application/json"))
                        .addUrlSegmentParam(new KeyValuePair<string, object>("idCustomer", 7)) // credenciales estaticas
                        .buildRquest();

                    List<ProyectoModel> projectModel = RequestAPI.deserilizeProject(responseRequest);

                    int x = 2;

                    return View(projectModel);
                    /*string json = response.Content.ToString();
                    int respuesta = 3;
                    if (respuesta == 3)
                    {
                        //TODO OK
                        //Pedir el nombre de la persona
                        //Convertir el json que me llega a una List
                        //List = json.toList();
                        ViewBag.lista = json;
                        return View(persona);
                    }
                    else if (respuesta == 2)
                    {
                        //CONTRASEÑA INCORRECTA
                        estadoContraseña = 1;
                    }
                    else
                    {
                        //USUARIO NO EXISTE
                        estadoUsuario = 1;
                        antiguoUsuario = persona.userName;
                    }*/
                }
                else
                {
                    //CONTRASEÑA NO INTRODUCIDA
                    estadoContraseña = 2;
                    antiguoUsuario = persona.userName;
                }
            }
            else
            {
                //USUARIO NO INTRODUCIDO
                estadoUsuario = 2;
                if (persona.contraseña == null)
                {
                    //CONTRASEÑA NO INTRODUCIDA
                    estadoContraseña = 2;
                }
            }

            return RedirectToAction("LogIn", "Home", new
            {
                estadoUsuario,
                estadoContraseña,
                antiguoUsuario
            });
        }
        [HttpGet("/Home/{operacion}", Name = "Products_List")]
        public IActionResult TimeLineOperacion(ProyectoModel operacion)
        {
            return View(operacion);
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
