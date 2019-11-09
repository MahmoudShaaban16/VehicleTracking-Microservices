using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.VehiclePing.Service.Services;

namespace VehicleTracking.VehiclePing.API.Commands
{
    public class SendPingRequestCommandHandler:IRequestHandler<SendPingRequestCommand,SendPingRequestCommandResult>
    {
        private readonly IPingService _pingService;
        public SendPingRequestCommandHandler(IPingService pingService)
        {
            _pingService = pingService;
        }
        public async Task<SendPingRequestCommandResult> Handle(SendPingRequestCommand request, CancellationToken cancellationToken)
        {
            var pingStatus = await _pingService.SendPingRequestAsync(request.VehicleIP);
            return new SendPingRequestCommandResult() { PingStatus = pingStatus, PingResponseDate = DateTime.Now };
        }
    }
}
