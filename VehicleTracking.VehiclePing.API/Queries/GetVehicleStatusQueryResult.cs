using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.VehiclePing.Service.Models;

namespace VehicleTracking.VehiclePing.API.Queries
{
    public class GetVehicleStatusQueryResult
    {
        

        public Service.Models.VehiclePing VehiclePingModel { get; internal set; }
    }
}
