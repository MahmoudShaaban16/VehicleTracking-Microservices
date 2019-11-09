using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehiclePing.API.Queries
{
    public class GetVehicleStatusQuery:IRequest<GetVehicleStatusQueryResult>
    {
        public int VehicleId { get; set; }

    }
}
