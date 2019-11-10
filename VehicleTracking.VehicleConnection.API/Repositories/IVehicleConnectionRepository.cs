using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = VehicleTracking.VehicleConnection.API.Models;
namespace VehicleTracking.VehicleConnection.API.Repositories
{
    interface IVehicleConnectionRepository
    {
        Task AddVehicleConnectionAsync(models.VehicleConnection vehicleConnection);
    }
}
