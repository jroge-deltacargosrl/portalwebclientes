using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class EtapaModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sequence { get; set; }
        public int projectId { get; set; }

        // adecuacion: etapa contiene muchas tareas
        public List<TareaModel> tasks { get; set; } = new List<TareaModel>();
    }
}
