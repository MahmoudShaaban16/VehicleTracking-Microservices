using System;

namespace VehicleTracking.Core.IntegrationEvents
{
    public class Event:IEvent
    {
        public Event()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
        }
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set ; }
    }
}
