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
                        .addHeader(new KeyValuePair<string, object>("Accept","application/json"))
                        .addRequest(new RestRequest("operation/{idCustomer}",Method.GET))
                        .addUrlSegmentParam(new KeyValuePair<string, object>("idCustomer", 7))
                        .buildRquest();

                    int x = 2;
                        
                       



                    /*var client = new RestClient("http://deltawebapi.azurewebsites.net/api/v1/operations/");
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Connection", "keep-alive");
                    request.AddHeader("Content-Length", "26");
                    request.AddHeader("Accept-Encoding", "gzip, deflate");
                    request.AddHeader("Cookie", "ARRAffinity=419a3fd042e09f6a2a8c01997b56c1bc63e7fa41cfbb8e4472612963a6dd2564");
                    request.AddHeader("Host", "deltawebapi.azurewebsites.net");
                    request.AddHeader("Postman-Token", "2ee76cf0-4044-4abf-a14e-653ce68188b3,627cc292-00b1-4912-be84-9981691d9cf5");
                    request.AddHeader("Cache-Control", "no-cache");
                    request.AddHeader("User-Agent", "PostmanRuntime/7.15.2");
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
                        persona.userName = json.Length.ToString();
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
