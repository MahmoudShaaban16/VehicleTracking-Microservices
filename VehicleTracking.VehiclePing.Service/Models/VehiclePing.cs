using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.VehiclePing.Service.Models
{
    public class VehiclePing
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "vehicleId")]
        public int VehicleId { get; set; }
        [JsonProperty(PropertyName = "pingDate")]
        public DateTime PingDate { get; set; }
        [JsonProperty(PropertyName = "vehicleIP")]
        public string VehicleIP { get; set; }
        [JsonProperty(PropertyName = "pingStatus")]
        public PingStatus PingStatus { get; set; }
    }
}
