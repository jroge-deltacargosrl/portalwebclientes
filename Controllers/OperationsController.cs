using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortalWebCliente.Models;
using PortalWebCliente.Models.Infrastructure;
using PortalWebCliente.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace PortalWebCliente.Controllers
{
    public class OperationsController : Controller
    {
        private string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
        private IHostingEnvironment _hostingEnv;

        public OperationsController(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        [HttpGet("/Timeline/{projectName}", Name = "aux")]
        public IActionResult Timeline(string projectName)
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

        [HttpGet]
        public IActionResult Index()
        {
            UserResponse actualUser = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
            List<ProjectModel> operations = responseFromOperationAPI(actualUser.id);
            List<ProjectModel> runningOperations = new List<ProjectModel>();
            List<ProjectModel> historyOperations = new List<ProjectModel>();
            foreach (ProjectModel p in operations)
            {
                if (!isFinalizedOperation(p))
                {
                    runningOperations.Add(p);
                }
                else
                {
                    historyOperations.Add(p);
                }
            }
            HttpContext.Session.setObjectAsJson("listaDeProyectosJSON", operations);
            ViewBag.userEmail = actualUser.email;
            ViewBag.runningOperations = runningOperations;
            ViewBag.historyOperations = historyOperations;
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel usuario)
        {
            int estadoUsuario = 0, estadoContraseña = 0; string antiguoUsuario = "";
            if (!isEmpty(usuario.email))
            {
                if (!isEmpty(usuario.password))
                {
                    UserResponse response = responseFromLoginAPI(usuario);
                    HttpContext.Session.setObjectAsJson("usuarioResponseJSON", response);
                    if (response.responseType == 3)
                    {
                        //All OK
                        List<ProjectModel> operations = responseFromOperationAPI(response.id);
                        List<ProjectModel> runningOperations = new List<ProjectModel>();
                        List<ProjectModel> historyOperations = new List<ProjectModel>();
                        foreach (ProjectModel p in operations)
                        {
                            if (!isFinalizedOperation(p))
                            {
                                runningOperations.Add(p);
                            }
                            else
                            {
                                historyOperations.Add(p);
                            }
                        }
                        //This is for the some operation's Timeline
                        HttpContext.Session.setObjectAsJson("listaDeProyectosJSON", operations);
                        ViewBag.userEmail = usuario.email;
                        ViewBag.runningOperations = runningOperations;
                        ViewBag.historyOperations = historyOperations;
                        return View();
                    }
                    else if (response.responseType == 2)
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
            return RedirectToAction("Login", "Home", new
            {
                estadoUsuario,
                estadoContraseña,
                antiguoUsuario
            });
        }

        [HttpPost]
        public JsonResult UploadFile(ProjectModel project)
        {
            IFormFile imageFile = project.stages[0].tasks[0].document;
            string cad = "ERROR";
            if (ModelState.IsValid)
            {
                var filename = ContentDispositionHeaderValue.Parse(imageFile.ContentDisposition).FileName.Trim('"');
                var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("Common\\Images\\"));
                var savePath = Path.Combine(targetDirectory, filename);
                imageFile.CopyTo(new FileStream(savePath, FileMode.Create));
                //model.ImageFile = filename;
                //_imageUploadAppService.UserCreate(model);
                cad = "OK";
            }
            return Json(cad);
        }

        private bool isEmpty(string word)
        {
            return word == null;
        }

        private UserResponse responseFromLoginAPI(UserModel user)
        {
            var responseLogin = new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(new RestRequest("access/", Method.POST, DataFormat.Json))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .addBodyData(user)
                .buildRequest();
            return JsonConvert.DeserializeObject<UserResponse>(responseLogin);
        }

        private List<ProjectModel> responseFromOperationAPI(int id)
        {
            var responseProjects = new RequestAPI()
                           .addClient(new RestClient(urlRequest))
                           .addRequest(new RestRequest("operation/{idCustomer}", Method.GET))
                           .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                           .addUrlSegmentParam(new KeyValuePair<string, object>("idCustomer", id)) // credenciales estaticas
                           .buildRequest();
            return JsonConvert.DeserializeObject<List<ProjectModel>>(responseProjects);
        }

        private bool isFinalizedOperation(ProjectModel p)
        {
            foreach (StageModel stage in p.stages)
            {
                foreach (TaskModel task in stage.tasks)
                {
                    if (task.kanbanState != "done")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}