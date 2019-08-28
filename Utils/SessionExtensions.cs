using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PortalWebCliente.Utils.UtilsPortal;

namespace PortalWebCliente.Utils
{
    public static class SessionExtensions
    {
        public static void setObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T getObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return isNull(value) ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }


}
