using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PortalWebCliente.Models;
using RestSharp;
using PortalWebCliente.Models.Infrastructure;
using Newtonsoft.Json;
using static PortalWebCliente.Utils.SessionExtensions;
using Microsoft.AspNetCore.Hosting;

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

        //Metodo encargado de verificar el login
        [HttpPost]
        public IActionResult Index(UserModel usuario)
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
                        .addRequest(new RestRequest("access/", Method.POST, DataFormat.Json))
                        .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                        .addBodyData(usuario)
                        .buildRequest();
                    UserResponse usuarioResponse = JsonConvert.DeserializeObject<UserResponse>(responseLogin);
                    HttpContext.Session.setObjectAsJson("usuarioResponseJSON", usuarioResponse);
                    if (usuarioResponse.responseType == 3)
                    {
                        //TODO OK
                        var responseProjects = new RequestAPI()
                            .addClient(new RestClient(urlRequest))
                            .addRequest(new RestRequest("operation/{idCustomer}", Method.GET))
                            .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                            .addUrlSegmentParam(new KeyValuePair<string, object>("idCustomer", usuarioResponse.id)) // credenciales estaticas
                            .buildRequest();
                        List<ProjectModel> projectList = JsonConvert.DeserializeObject<List<ProjectModel>>(responseProjects);
                        HttpContext.Session.setObjectAsJson("listaDeProyectosJSON", projectList);
                        UserResponse usuarioActual = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
                        ViewBag.userEmail = usuarioActual.email;
                        return View(projectList);
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

        [HttpGet]
        public IActionResult Index()
        {
            UserResponse usuarioActual = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
            string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
            var responseProjects = new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(new RestRequest("operation/{idCustomer}", Method.GET))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .addUrlSegmentParam(new KeyValuePair<string, object>("idCustomer", usuarioActual.id)) // credenciales estaticas
                .buildRequest();
            List<ProjectModel> projectList = JsonConvert.DeserializeObject<List<ProjectModel>>(responseProjects);
            HttpContext.Session.setObjectAsJson("listaDeProyectosJSON", projectList);
            ViewBag.userEmail = usuarioActual.email;
            return View(projectList);
        }

        [HttpGet]//("/Home/{proyectName}", Name = "aux")]
        public IActionResult TimeLineOperacion(string proyectName)
        {
            List<ProjectModel> listaDeProyectos =
                HttpContext.Session.getObjectFromJson
                <List<ProjectModel>>("listaDeProyectosJSON");
            foreach (ProjectModel proyecto in listaDeProyectos)
            {
                if (proyecto.name.Equals(proyectName))
                {
                    UserResponse usuarioActual = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
                    ViewBag.userEmail = usuarioActual.email;
                    return View(proyecto);
                }
            }
            //NUNCA PASA POR AQUI
            ProjectModel operacion = new ProjectModel();
            operacion.stages = new List<StageModel>()
            {
                new StageModel()
                {
                    id=1,
                    name="Etapa1",
                    projectId=1,
                    sequence=1,
                    tasks=new List<TaskModel>()
                    {
                        new TaskModel
                        {
                            id=1,
                            name="Tarea1",
                            projectId=1,
                            stageId=1,
                            date_start=new DateTime(2019,01,01),
                            kanbanState="normal"
                        },
                        new TaskModel
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
                new StageModel()
                {
                    id=2,
                    name="etapa2",
                    projectId=2,
                    sequence=2,
                    tasks=new List<TaskModel>()
                    {
                        new TaskModel
                        {
                            id=3,
                            name="Tarea3",
                            projectId=2,
                            stageId=2,
                            date_start=new DateTime(2019,01,01),
                            kanbanState="normal"
                        },
                        new TaskModel
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
                new StageModel()
                {
                    id=3,
                    name="etapa3",
                    projectId=3,
                    sequence=3,
                    tasks=new List<TaskModel>()
                    {
                        new TaskModel
                        {
                            id=5,
                            name="Tarea5",
                            projectId=3,
                            stageId=3,
                            date_start=new DateTime(2019,01,01),
                            kanbanState="normal"
                        },
                        new TaskModel
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
