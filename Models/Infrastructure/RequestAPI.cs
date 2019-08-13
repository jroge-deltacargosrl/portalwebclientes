using RestSharp;
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


        public RequestAPI():this(null,null) { }
        

        public RequestAPI(RestClient client, RestRequest request)
        {
            this.client = client;
            this.request = request;
        }


        public bool requestValid() => !isNull(client) && !isNull(request);

        // rediseñar este metodo de una forma optima para futuras iteraciones
        public IRestRequest addParameters(Dictionary<string,object> paramsRequest)
        {
            IRestRequest requestCurrent = null;
            foreach (KeyValuePair<string,object> item in paramsRequest)
            {
                 requestCurrent = addParameter(item);
            }
            return requestCurrent;
        }

        public IRestRequest addHeader(KeyValuePair<string, object> paramHeader) => request.AddHeader(paramHeader.Key,paramHeader.Value.ToString());
        public IRestRequest addParameter(KeyValuePair<string, object> param) => request.AddParameter(param.Key, param.Value);
        
        /// <summary>
        /// Metodo que ejecuta la solicitud HTTP/ HTTPS desde el lado del cliente hacia el servidor, procesa la informacion y lanza una respuesta de parte del servidor
        /// </summary>
        /// <returns></returns>
        public string executeRequest()
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
