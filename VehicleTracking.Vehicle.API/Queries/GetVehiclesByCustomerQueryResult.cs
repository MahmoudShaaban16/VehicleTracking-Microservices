using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Vehicle.API.ViewModels;

namespace VehicleTracking.Vehicle.API.Queries
{
    public class GetVehiclesByCustomerQueryResult
    {
        public List<VehicleViewModel> Vehicles { get; internal set; }
    }
}
