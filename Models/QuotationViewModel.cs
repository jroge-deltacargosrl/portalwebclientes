using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalWebCliente.Models
{
    public class QuotationViewModel
    {
        public List<ServiceTypeModel> serviceTypes { get; set; }
        public List<MacroRouteModel> macroRoutes { get; set; }
        public List<TruckTypeModel> trucksTypes { get; set; }
    }
}