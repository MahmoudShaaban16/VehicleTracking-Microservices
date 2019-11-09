using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Core.IntegrationEvents;
using VehicleTracking.VehiclePing.API.Events;


namespace VehicleTracking.VehiclePing.API.IntegrationEvents.EventHandlers
{
   

    public class ConnectionSentByVehicleEventHandler : IEventHandler<ConnectionSentByVehicleEvent>
    {
       
        private readonly ILogger<ConnectionSentByVehicleEventHandler> _logger;

        public ConnectionSentByVehicleEventHandler(
           
            ILogger<ConnectionSentByVehicleEventHandler> logger)
        {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task HandleAsync(ConnectionSentByVehicleEvent connectionSentByVehicleEvent)
        {
            
        }
    }
}
