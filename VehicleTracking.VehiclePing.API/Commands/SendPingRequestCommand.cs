using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehiclePing.API.Commands
{
    public class SendPingRequestCommand:IRequest<SendPingRequestCommandResult>
    {
        public int VehicleId { get; set; }
        public string VehicleIP { get; set; }
    }
}
