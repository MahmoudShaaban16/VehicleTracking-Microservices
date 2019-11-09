using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.Vehicle.API.Queries
{
    public class GetVehiclesByCustomerQuery: IRequest<GetVehiclesByCustomerQueryResult>
    {
        public int CustomerId { get; internal set; }
       
    }
}
