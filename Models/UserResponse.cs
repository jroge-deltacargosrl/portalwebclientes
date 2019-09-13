using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class UserResponse
    {
        public int id { get; set; }
        public string email { get; set; }
        public int responseType { get; set; }
    }
}
