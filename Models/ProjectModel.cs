using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class ProjectModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<StageModel> stages { get; set; } = new List<StageModel>();
    }
}
