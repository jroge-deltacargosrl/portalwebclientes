using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortalWebCliente.Models;
using PortalWebCliente.Models.Infrastructure;
using PortalWebCliente.Utils;
using RestSharp;
using System.Collections.Generic;

namespace PortalWebCliente.Controllers
{
    public class QuotationController : Controller
    {
        public IActionResult Create()
        {
            string urlRequest = @"http://deltacargoapi.azurewebsites.net/api/v1/";
            var responseProjects = new RequestAPI()
                .addClient(new RestClient(urlRequest))
                .addRequest(new RestRequest("quotation/", Method.GET))
                .addHeader(new KeyValuePair<string, object>("Accept", "application/json"))
                .buildRequest();
            QuotationViewModel quotationFormat = JsonConvert.DeserializeObject<QuotationViewModel>(responseProjects);
            UserResponse usuarioActual = HttpContext.Session.getObjectFromJson<UserResponse>("usuarioResponseJSON");
            ViewBag.userEmail = usuarioActual.email;
            return View(quotationFormat);
            //NUNCA PASA POR AQUI
            quotationFormat = new QuotationViewModel()
            {
                serviceTypes = new List<ServiceTypeModel>()
                {
                    new ServiceTypeModel()
                    {
                        id=1,
                        name ="Transporte Urbano"
                    },
                    new ServiceTypeModel()
                    {
                        id=2,
                        name ="Almacenamiento de Carga"
                    },
                    new ServiceTypeModel()
                    {
                        id=3,
                        name ="Transporte Nacional"
                    },
                    new ServiceTypeModel()
                    {
                        id=4,
                        name ="Transporte Internacional"
                    }
                },
                macroRoutes = new List<MacroRouteModel>()
                {
                    new MacroRouteModel()
                    {
                        id=1,
                        name="Bolivia"
                    },
                    new MacroRouteModel()
                    {
                        id=2,
                        name="Argentina"
                    },
                    new MacroRouteModel()
                    {
                        id=3,
                        name="Peru"
                    }
                },
                trucksTypes=new List<TruckTypeModel>()
                {
                    new TruckTypeModel()
                    {
                        id=1,
                        tipo="A"
                    },
                    new TruckTypeModel()
                    {
                        id=2,
                        tipo="B"
                    },
                    new TruckTypeModel()
                    {
                        id=3,
                        tipo="C"
                    }
                }
            };
            return View(quotationFormat);
        }

    }
}
