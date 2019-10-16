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
       
        [HttpGet("/Home/{projectName}", Name = "aux")]
        public IActionResult TimeLineOperacion(string projectName)
        {
            List<ProjectModel> listaDeProyectos =
                HttpContext.Session.getObjectFromJson
                <List<ProjectModel>>("listaDeProyectosJSON");
            foreach (ProjectModel proyecto in listaDeProyectos)
            {
                if (proyecto.name.Equals(projectName))
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

