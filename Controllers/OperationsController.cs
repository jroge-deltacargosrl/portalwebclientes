using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortalWebCliente.Models;
using PortalWebCliente.Models.Infrastructure;
using PortalWebCliente.Utils;
using RestSharp;
using System.Collections.Generic;

namespace PortalWebCliente.Controllers
{
    public class OperationsController : Controller
    {
        private string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";

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