using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class TareaModel
    {
        public int id { get; set; }
        public string kanbanState { get; set; }
        public string name { get; set; }
        public DateTime date_start { get; set; }
        public int projectId { get; set; }

        // adecuacion parcial: 
        public int stageId { get; set; }
    }
}
