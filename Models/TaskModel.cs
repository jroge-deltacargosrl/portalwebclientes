using System;

namespace PortalWebCliente.Models
{
    public class TaskModel
    {
        public int id { get; set; }
        public string kanbanState { get; set; }
        public string name { get; set; }
        public DateTime date_start { get; set; }
        public int projectId { get; set; }
        // adecuacion parcial:
        public int stageId { get; set; }

        /*Nuevos atributos:JROGE*/
        public bool canUpload { get; set; }
        public bool uploaded { get; set; }
    }
}