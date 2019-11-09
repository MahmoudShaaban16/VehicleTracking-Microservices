using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehicleConnection.API.Models
{
    public class VehicleConnection
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "vehicleId")]
        public  int VehicleId { get; set; }
        [JsonProperty(PropertyName = "connectionDate")]
        public DateTime ConnectionDate { get; set; }
    }
}
