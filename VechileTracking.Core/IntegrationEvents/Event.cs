using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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
