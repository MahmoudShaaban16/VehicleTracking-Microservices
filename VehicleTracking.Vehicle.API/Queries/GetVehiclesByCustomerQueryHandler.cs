using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Vehicle.API.Repositories;
using VehicleTracking.Vehicle.API.ViewModels;

namespace VehicleTracking.Vehicle.API.Queries
{
    public class GetVehiclesByCustomerQueryHandler : IRequestHandler<GetVehiclesByCustomerQuery, GetVehiclesByCustomerQueryResult>
    {
        private readonly IVehicleRepository _vehicleRepository;
        public GetVehiclesByCustomerQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<GetVehiclesByCustomerQueryResult> Handle(GetVehiclesByCustomerQuery request, CancellationToken token)
        {
            List<Vehicle.API.Models.Vehicle> vehicles = _vehicleRepository.Get(request.CustomerId);
            List<VehicleViewModel> vehicleVMs = new List<VehicleViewModel>();
            vehicles.ForEach(v => vehicleVMs.Add(new VehicleViewModel() { VehicleNumber = v.VehicleNumber, RegNumbr = v.RegNumber }));
            return new GetVehiclesByCustomerQueryResult() { Vehicles = vehicleVMs };
        }
    }
}
