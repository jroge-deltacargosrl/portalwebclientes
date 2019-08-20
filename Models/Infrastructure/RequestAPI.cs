using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PortalWebCliente.Utils.UtilsPortal;


namespace PortalWebCliente.Models.Infrastructure
{
    public class RequestAPI
    {
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
        public IRestResponse response { get; set; }

        public RequestAPI() : this(null, null) { }

        public RequestAPI(RestClient client, RestRequest request)
        {
            this.client = client;
            this.request = request;
        }

        // Metodos de construccion por partes
        public RequestAPI addClient(RestClient client)
        {
            this.client = client;
            return this;
        }

        public RequestAPI addRequest(RestRequest request)
        {
            this.request = request;
            return this;
        }

        public bool requestValid() => !isNull(client) && !isNull(request);

        // rediseñar este metodo de una forma optima para futuras iteraciones
        public RequestAPI addParameters(Dictionary<string, object> paramsRequest, ParameterType paramType)
        {
            foreach (KeyValuePair<string, object> item in paramsRequest)
            {
                addParameter(item, paramType);
            }
            return this;
        }

        public RequestAPI setRequestFormat(DataFormat format)
        {
            request.RequestFormat = format;
            return this;
        }

        public RequestAPI addBodyData(object param)
        {
            request.AddBody(param);
            return this;
        }

        public RequestAPI addHeader(KeyValuePair<string, object> paramHeader)
        {
            request.AddHeader(paramHeader.Key, paramHeader.Value.ToString());
            return this;
        }

        public RequestAPI addParameter(KeyValuePair<string, object> param, ParameterType paramType)
        {
            request.AddParameter(param.Key, param.Value, paramType);
            return this;
        }

        public RequestAPI addUrlSegmentParam(KeyValuePair<string,object> param)
        {
            request.AddUrlSegment(param.Key, param.Value);
            return this;
        }




        /// <summary>
        /// Metodo que ejecuta la solicitud HTTP/ HTTPS desde el lado del cliente hacia el servidor, procesa la informacion y lanza una respuesta de parte del servidor
        /// </summary>
        /// <returns></returns>
        public string buildRquest() 
        {
            try
            {
                string contentOut = string.Empty;
                if (requestValid())
                {
                    response = client.Execute(request);
                    contentOut = response.Content;
                }
                return contentOut;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        // readecuar esta seccion
        public static List<ProyectoModel> deserilizeProject(string content)
        {
            return JsonConvert.DeserializeObject<List<ProyectoModel>>(content);
        }


        /***
           public static List<ItemCatalogoInfraestructura> getInfraestructuras(string citeInfra)
        {
            try
            {
                var client = new RestClient(URL_OBTENER_CATALOGO_ESPECIFICO);
                var request = new RestRequest(Method.POST);
                request.AddParameter("citeInfraestructura", citeInfra);
                //request.AddHeader("Authorization", string.Format("Bearer {0}", "eyJhb.eyJmZWNo._I4oj"));
                request.AddHeader("Authorization", string.Format("Bearer {0}", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJmZWNoYSI6IjIwMTgwODAxMTU0NTIzIiwic2lyZWhpZHJvIjoiQU5IMDIyMzMiLCJvcGVyYWRvciI6IkFJUiBCUCBCT0xJVklBIFMuQS4gQUJCU0EiLCJ2aWdlbmNpYSI6IjIwMjgxMjMxMDAwMDAwIn0._I4ojD5n1WATqGolIOAUPHXPyaED2ISKspFYMSiODYY"));
        request.AddHeader("Authorization", string.Format("Bearer {0}", TOKEN));
                IRestResponse response = client.Execute(request);
        var content = response.Content;
        ObtenerCatalogoEspecificoJSON catalogoEspecifico = ObtenerCatalogoEspecificoJSON.FromJson(content);
                return catalogoEspecifico.OResultado != null ? new List<ItemCatalogoInfraestructura>(catalogoEspecifico.OResultado.CatalogoInfraestructura) : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
         */

    }
}
