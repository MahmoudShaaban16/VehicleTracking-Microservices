using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Core.IntegrationEvents;
using VehicleTracking.VehiclePing.API.Events;
using VehicleTracking.VehiclePing.Service.Services;

namespace VehicleTracking.VehiclePing.API.IntegrationEvents.EventHandlers
{
   

    public class ConnectionSentByVehicleEventHandler : IEventHandler<ConnectionSentByVehicleEvent>
    {
       
        private readonly ILogger<ConnectionSentByVehicleEventHandler> _logger;
        private readonly IPingService _pingService;

        public ConnectionSentByVehicleEventHandler(
            IPingService pingService,
            ILogger<ConnectionSentByVehicleEventHandler> logger)
        {
            _pingService = pingService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Handling a new vehicle connection sent from device
        public async Task HandleAsync(ConnectionSentByVehicleEvent connectionSentByVehicleEvent)
        {
            _logger.LogInformation("Handling a vehicle connection event handler");
            var pingStatus = await _pingService.SendPingRequestAsync(connectionSentByVehicleEvent.VehicleIP);
            await _pingService.PersistPingInDbAsync(Guid.NewGuid().ToString(), connectionSentByVehicleEvent.VehicleId, connectionSentByVehicleEvent.VehicleIP, pingStatus, DateTime.Now);
        }
    }
}
