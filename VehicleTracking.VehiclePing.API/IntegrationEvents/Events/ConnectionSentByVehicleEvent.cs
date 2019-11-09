using VehicleTracking.Core.IntegrationEvents;

namespace VehicleTracking.VehiclePing.API.Events
{
    public class ConnectionSentByVehicleEvent : Event
    {
        public int VehicleId { get; set; }
        public string VehicleIP { get; set; }
    }
}