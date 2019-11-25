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

namespace PortalWebCliente.Controllers
{
    public class OperationsController : Controller
    {
        private string urlRequest =
            //@"http://deltacargoapi.azurewebsites.net/api/v1/"
            @"https://localhost:44333/api/v1/"
            //@"http://192.168.1.40:44333/api/v1/"
            ;
        private IHostingEnvironment _hostingEnv;

        public OperationsController(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        [HttpGet("/Timeline/{projectName}", Name = "aux")]
        public IActionResult Timeline(string projectName)
        {
            UserResponse usuarioActual = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
            ViewBag.userEmail = usuarioActual.email;
            ViewBag.project = getProjectWithName(projectName);
            return View();
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
        public IActionResult UploadFile(string fileIds, IFormFile file)
        {
            string fileName = null;
            string stringFile = "";
            if (file != null)
            {
                fileName = fileIds;
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        stringFile = Convert.ToBase64String(fileBytes);
                    }
                }
            }
            ViewBag.file = fileName == null ? "NULL" : stringFile;//uniqueFile;
            UserResponse usuarioActual = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
            ViewBag.userEmail = usuarioActual.email;

            string[] datos = fileIds.Split("#");
            string[] names = datos[0].Split("*");

            string[] ids = datos[1].Split("_");
            int projectId = Convert.ToInt32(ids[2]);
            int taskId = Convert.ToInt32(ids[0]);

            string taskFileName = $"{names[0]}-{names[1]}({projectId}{taskId}).pdf";

            FileModel newFileModel = new FileModel {
                idTask = taskId,
                idProject = projectId,
                documentContent = stringFile,
                documentName = taskFileName
            };
            int response = resonseFromUploadFileAPI(newFileModel).responseType;
            ViewBag.response = response;
            UserResponse actualUser = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
            List<ProjectModel> operations = responseFromOperationAPI(actualUser.id);
            HttpContext.Session.setObjectAsJson("listaDeProyectosJSON", operations);
            ViewBag.userEmail = actualUser.email;
            ViewBag.project = getProjectWithId(projectId);
            return View("Timeline");
            //return View();
        }

        private ProjectModel getProjectWithName(string projectName)
        {
            List<ProjectModel> listaDeProyectos = HttpContext.Session.getObjectFromJson<List<ProjectModel>>("listaDeProyectosJSON");
            foreach (ProjectModel proyecto in listaDeProyectos)
            {
                if (proyecto.name.Equals(projectName))
                {
                    return proyecto;
                }
            }
            return null;
        }

        private ProjectModel getProjectWithId(int projectId)
        {
            List<ProjectModel> listaDeProyectos = HttpContext.Session.getObjectFromJson<List<ProjectModel>>("listaDeProyectosJSON");
            foreach (ProjectModel proyecto in listaDeProyectos)
            {
                if (proyecto.id==projectId)
                {
                    return proyecto;
                }
            }
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
            return operacion;
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

        private FileResponse resonseFromUploadFileAPI(FileModel file)
        {
            RestRequest request = new RestRequest("operation/", Method.POST, DataFormat.Json);

            var responseFile= new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(request)
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .addBodyData(file)
                .buildRequest();
            return JsonConvert.DeserializeObject<FileResponse>(responseFile);
        }

        private List<ProjectModel> responseFromOperationAPI(int id)
        {
            var responseProjects = new RequestAPI()
                           .addClient(new RestClient(urlRequest))
                           .addRequest(new RestRequest("operation/{idClient}", Method.GET))
                           .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                           .addUrlSegmentParam(new KeyValuePair<string, object>("idClient", id)) // credenciales estaticas
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