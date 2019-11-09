using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.VehiclePing.Service.Models;

namespace VehicleTracking.VehiclePing.Service.Services
{
    public interface IPingService
    {
        Task PersistPingInDbAsync(string id, int vehicleId, string vehicleIP, PingStatus pingStatus, DateTime pingDate);
        Task<PingStatus> SendPingRequestAsync(string vehicleIP);
        Task<VehiclePing.Service.Models.VehiclePing> GetRecentByAsync(int vehicleId);
    }
}
