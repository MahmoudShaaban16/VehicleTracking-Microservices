using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking.Core.IntegrationEvents
{
    public interface IEvent
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
    }
}
