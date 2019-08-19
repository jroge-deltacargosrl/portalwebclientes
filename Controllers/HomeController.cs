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
                    var client = new RestClient("http://deltawebapi.azurewebsites.net/api/v1/operations/");
                    var request = new RestRequest(Method.GET);
                    //request.AddHeader("cache-control", "no-cache");
                    //request.AddHeader("Connection", "keep-alive");
                    //request.AddHeader("Content-Length", "26");
                    //request.AddHeader("Accept-Encoding", "gzip, deflate");
                    //request.AddHeader("Cookie", "ARRAffinity=419a3fd042e09f6a2a8c01997b56c1bc63e7fa41cfbb8e4472612963a6dd2564");
                    //request.AddHeader("Host", "deltawebapi.azurewebsites.net");
                    //request.AddHeader("Postman-Token", "c519f40d-72c6-4ef4-9543-9775dbfab5dd,a3a83752-3a36-4e76-8d97-018a5a21708d");
                    //request.AddHeader("Cache-Control", "no-cache");
                    //request.AddHeader("Accept", "*/*");
                    //request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
                    request.AddHeader("Content-Type", "application/json");
                    request.AddParameter("undefined", "{\n\t\"id\":7,\n\t\"message\":\"\"\n}", ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    string json = response.Content.ToString();
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
                    }
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
