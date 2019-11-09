using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Core.Infrastructure;
using VehicleTracking.Vehicle.API.Infrastructure.EF;
using VehicleTracking.Vehicle.API.Models;

namespace VehicleTracking.Vehicle.API.Repositories
{
    public class VehicleRepository:IVehicleRepository
    {
        private readonly VehicleContext _context;

        public VehicleRepository(VehicleContext context)
        {
            _context = context;
        }

        public List<Models.Vehicle> Get(int customerId)
        {
            return _context.Vehicles.Where(v => v.CustomerId == customerId).ToList();
        }

       
    }
}
