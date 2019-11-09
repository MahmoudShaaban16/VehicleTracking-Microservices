using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.VehiclePing.Service.Services;

namespace VehicleTracking.VehiclePing.API.Queries
{
    public class GetVehicleStatusQueryHandler:IRequestHandler<GetVehicleStatusQuery,GetVehicleStatusQueryResult>
    {
        private readonly IPingService _pingService;
        public GetVehicleStatusQueryHandler(IPingService pingService)
        {
            _pingService = pingService;
        }
        public async Task<GetVehicleStatusQueryResult> Handle(GetVehicleStatusQuery query,CancellationToken cancellationToken )
        {
            var ping = await _pingService.GetRecentByAsync(query.VehicleId);
            var pingQueryResult = new GetVehicleStatusQueryResult();
            if (ping.PingDate==null || ping.PingStatus==Service.Models.PingStatus.Disconnected)
            {
                pingQueryResult.VehiclePingModel = ping;
                pingQueryResult.VehiclePingModel.PingStatus = Service.Models.PingStatus.Disconnected;
                
            }
            else if(DateTime.Compare(ping.PingDate,DateTime.Now)==0)
            {
                pingQueryResult.VehiclePingModel = ping;
            }
            else
            {
                pingQueryResult.VehiclePingModel = new Service.Models.VehiclePing() { VehicleId = query.VehicleId, PingStatus = Service.Models.PingStatus.Disconnected };
            }
            return pingQueryResult;

        }
    }
}
