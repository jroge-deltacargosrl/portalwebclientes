using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Utils
{
    public static class UtilsPortal
    {

        public static string environment { get; set; }


        public static string URL_LISTAR_TABLAS_ODOO_METADATA_PORTAL { get; private set; }
        public static string URL_VERIFICAR_LOGIN_USUARIO_PORTAL { get; private set; }
        public static string URL_REGISTRO_USUARIO_PORTAL { get; private set; }
        public static string URL_ACCESS_PORTAL_WEB { get; private set; }
        public static string URL_LISTAR_PROYECTOS_CLIENTE_PORTAL { get; private set; }
        public static string URL_OBTENER_PROYECTO_CLIENTE_PORTAL { get; private set; }

        public static void initVarEnviroment()
        {
            switch (environment)
            {
                case "developing":
                    URL_LISTAR_TABLAS_ODOO_METADATA_PORTAL = "https://localhost/TMS_WebServices/api/v1/getSchemmaOdoo/";
                    URL_VERIFICAR_LOGIN_USUARIO_PORTAL = "https://localhost/TMS_WebServices/api/v1/accessClient/";
                    URL_REGISTRO_USUARIO_PORTAL = "";
                    URL_LISTAR_PROYECTOS_CLIENTE_PORTAL = "https://localhost/TMS_WebServices/api/v1/projectsByCustomer/";
                    URL_ACCESS_PORTAL_WEB = "";
                    break;
                case "local production":
                    URL_LISTAR_TABLAS_ODOO_METADATA_PORTAL = "https://localhost/TMS_WebServices/api/v1/getSchemmaOdoo/";
                    URL_VERIFICAR_LOGIN_USUARIO_PORTAL = "https://localhost/TMS_WebServices/api/v1/accessClient/";
                    URL_REGISTRO_USUARIO_PORTAL = "";
                    URL_LISTAR_PROYECTOS_CLIENTE_PORTAL = "https://localhost/TMS_WebServices/api/v1/projectsByCustomer/";
                    URL_ACCESS_PORTAL_WEB = @"https://localhost:44333/api/v1/accessClient/";
                    break;
                case "cloud production":
                    break;
            }

        }


        /// <summary>
        /// Metodo que verifica si un objeto es un referencia valida o nula
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool isNull<T>(T value) => value == null;



    }
}
