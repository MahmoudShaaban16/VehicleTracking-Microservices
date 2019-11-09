using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehicleConnection.API.Commands
{
    public class RecordNewConnectionCommand:IRequest<RecordNewConnectionCommandResult>
    {
        public int VehicleId { get; set; }
        public string VehicleIP { get; set; }
        public DateTime ConnectionDate { get; set; }
    }
}
