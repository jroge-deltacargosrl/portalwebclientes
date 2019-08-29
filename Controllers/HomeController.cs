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
using Newtonsoft;
using RestSharp.Serialization.Json;
using Newtonsoft.Json;
using static PortalWebCliente.Utils.SessionExtensions;

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
        // Metodo encargado de verificar el login
        [HttpPost]
        public IActionResult Index(UsuarioModel usuario)
        {
            int estadoUsuario = 0, estadoContraseña = 0; string antiguoUsuario = "";
            if (usuario.email != null)
            {
                if (usuario.password != null)
                {
                    //Tabla de configuracion
                    string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
                    //string urlRequest = @"https://localhost:44333//api/v1/";
                    var responseLogin = new RequestAPI()
                        .addClient(new RestClient(urlRequest))
                        .addRequest(new RestRequest("access/", Method.POST,DataFormat.Json))
                        .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                        .addBodyData(usuario)
                        .buildRequest();
                    UsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<UsuarioResponse>(responseLogin);
                    HttpContext.Session.setObjectAsJson("usuarioResponseJSON",usuarioResponse);
                    if (usuarioResponse.responseType == 3)
                    {
                        //TODO OK
                        var responseProjects = new RequestAPI()
                            .addClient(new RestClient(urlRequest))
                            .addRequest(new RestRequest("operation/{idCustomer}", Method.GET))
                            .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                            .addUrlSegmentParam(new KeyValuePair<string, object>("idCustomer",usuarioResponse.id)) // credenciales estaticas
                            .buildRequest();
                        List<ProyectoModel> projectModel = JsonConvert.DeserializeObject<List<ProyectoModel>>(responseProjects);
                        HttpContext.Session.setObjectAsJson("listaDeProyectosJSON", projectModel);
                        UsuarioResponse usuarioActual = HttpContext.Session.getObjectFromJson<UsuarioResponse>("usuarioResponseJSON");
                        ViewBag.emailUsuarioActual = usuarioActual.email;
                        return View(projectModel);
                    }
                    else if (usuarioResponse.responseType == 2)
                    {
                        //CONTRASEÑA INCORRECTA
                        estadoContraseña = 1;
                        antiguoUsuario = usuario.email;
                    }
                    else
                    {
                        //USUARIO NO EXISTE
                        estadoUsuario = 1;
                        antiguoUsuario = usuario.email;
                    }
                }
                else
                {
                    //CONTRASEÑA NO INTRODUCIDA
                    estadoContraseña = 2;
                    antiguoUsuario = usuario.email;
                }
            }
            else
            {
                //USUARIO NO INTRODUCIDO
                estadoUsuario = 2;
                if (usuario.password == null)
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
        [HttpGet("/Home/{proyectName}", Name = "aux")]
        public IActionResult TimeLineOperacion(string proyectName)
        {
            List<ProyectoModel> listaDeProyectos = 
                HttpContext.Session.getObjectFromJson
                <List<ProyectoModel>>("listaDeProyectosJSON");
            foreach (ProyectoModel proyecto in listaDeProyectos)
            {
                if (proyecto.name.Equals(proyectName))
                {
                    UsuarioResponse usuarioActual = HttpContext.Session.getObjectFromJson<UsuarioResponse>("usuarioResponseJSON");
                    ViewBag.emailUsuarioActual = usuarioActual.email;
                    return View(proyecto);
                }
            }
            //NUNCA PASA POR AQUI
            ProyectoModel operacion = new ProyectoModel();
            operacion.stages = new List<EtapaModel>()
            {
                new EtapaModel()
                {
                    id=1,
                    name="Etapa1",
                    projectId=1,
                    sequence=1,
                    tasks=new List<TareaModel>()
                    {
                        new TareaModel
                        {
                            id=1,
                            name="Tarea1",
                            projectId=1,
                            stageId=1,
                            date_start=new DateTime(2019,01,01),
                            kanbanState="normal"
                        },
                        new TareaModel
                        {
                            id=2,
                            name="Tarea2",
                            projectId=1,
                            stageId=1,
                            date_start=new DateTime(2019,01,02),
                            kanbanState="done"
                        }
                    }
                },
                new EtapaModel()
                {
                    id=2,
                    name="etapa2",
                    projectId=2,
                    sequence=2,
                    tasks=new List<TareaModel>()
                    {
                        new TareaModel
                        {
                            id=3,
                            name="Tarea3",
                            projectId=2,
                            stageId=2,
                            date_start=new DateTime(2019,01,01),
                            kanbanState="normal"
                        },
                        new TareaModel
                        {
                            id=4,
                            name="Tarea4",
                            projectId=2,
                            stageId=2,
                            date_start=new DateTime(2019,01,02),
                            kanbanState="done"
                        }
                    }
                },
                new EtapaModel()
                {
                    id=3,
                    name="etapa3",
                    projectId=3,
                    sequence=3,
                    tasks=new List<TareaModel>()
                    {
                        new TareaModel
                        {
                            id=5,
                            name="Tarea5",
                            projectId=3,
                            stageId=3,
                            date_start=new DateTime(2019,01,01),
                            kanbanState="normal"
                        },
                        new TareaModel
                        {
                            id=6,
                            name="Tarea6",
                            projectId=3,
                            stageId=3,
                            date_start=new DateTime(2019,01,02),
                            kanbanState="done"
                        }
                    }
                }
            };
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
