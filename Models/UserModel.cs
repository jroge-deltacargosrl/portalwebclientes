using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class UserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Requerido")]
        public string email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Username muy largo, 20 caracteres permitidos como maximo")]
        public string password { get; set; }
    }
}
