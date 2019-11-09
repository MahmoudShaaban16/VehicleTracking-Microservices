using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = VehicleTracking.VehiclePing.Service.Models;
namespace VehicleTracking.VehiclePing.Service.Repositories
{
    public interface IVehiclePingRepository
    {
        Task AddPingAsync(models.VehiclePing pingRequest);
        Task<List<models.VehiclePing>> GetByAsync(int vehicleId);
    }
}
