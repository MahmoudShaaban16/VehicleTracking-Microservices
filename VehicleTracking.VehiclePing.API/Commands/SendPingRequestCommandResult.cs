using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.VehiclePing.Service.Models;

namespace VehicleTracking.VehiclePing.API.Commands
{
    
    public class SendPingRequestCommandResult
    {
        public PingStatus PingStatus { get; set; }
        public DateTime PingResponseDate {get;set;}
    }
}
