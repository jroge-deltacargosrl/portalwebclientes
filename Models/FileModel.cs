using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class FileModel
    {
        public int idTask {get;set;}
        public int idStage{ get; set; }
        public int idProject { get; set; }
        public string documentName { get; set; }
        public string documentContent { get; set; }
    }
}
