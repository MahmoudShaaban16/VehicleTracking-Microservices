using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.Vehicle.API.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string VehicleNumber { get; set; }
        public string RegNumber { get; set; }
        public bool IsConnected { get; set; }
    }
}
