using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehicleConnection.API.Models
{
    public class VehicleConnection
    {
        public int Id { get; set; }
        public  int VehicleId { get; set; }
        public DateTime ConnectionDate { get; set; }
    }
}
