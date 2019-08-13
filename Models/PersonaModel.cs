using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class PersonaModel
    {

        [Required(AllowEmptyStrings =false,ErrorMessage ="Campo Requerido")]
        public String userName { get; set; }

        [Required]
        [MaxLength(20,ErrorMessage = "Username muy largo, 20 caracteres permitidos como maximo")]
        public String contraseña { get; set; }
    }
}
