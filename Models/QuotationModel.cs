using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class QuotationModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public MacroRouteModel macroRouteOrigin { get; set; }
        public RouteModel idRouteOrigin { get; set; }
        public MacroRouteModel idMacroRouteDestination { get; set; }
        public RouteModel idRouteDestination { get; set; }
        public float loadWeight { get; set; }
        public float loadVolume { get; set; }
        public TruckTypeModel truckType { get; set; }
        public float storageCapacity { get; set; }
        public float storageTime { get; set; }
        public string comment { get; set; }
    }
}
