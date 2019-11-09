using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracking.Core.Infrastructure;
using VehicleTracking.Vehicle.API.Models;

namespace VehicleTracking.Vehicle.API.Repositories
{
    public interface IVehicleRepository:IRepository
    {
        List<Models.Vehicle> Get(int customerId);
       
    }
}