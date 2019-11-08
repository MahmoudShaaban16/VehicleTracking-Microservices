using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehiclePing.API.Models
{
    public class PingRequest
    {
        public int VehicleId { get; set; }
        public DateTime PingDate { get; set; }
        public string VehicleIP { get; set; }
        public int PingStatus { get; set; }
    }
}
