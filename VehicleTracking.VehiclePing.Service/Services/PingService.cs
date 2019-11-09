using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.VehiclePing.Service.Models;
using VehicleTracking.VehiclePing.Service.Repositories;

namespace VehicleTracking.VehiclePing.Service.Services
{
    public class PingService:IPingService
    {
        private readonly IVehiclePingRepository _vehiclePingRepository;
        private readonly Ping _ping;
        public PingService(IVehiclePingRepository vehiclePingRepository)
        {
            _vehiclePingRepository = vehiclePingRepository;
            _ping = new Ping();
        }

        public async Task<VehiclePing.Service.Models.VehiclePing> GetRecentByAsync(int vehicleId)
        {
            var pingRequests = await _vehiclePingRepository.GetByAsync(vehicleId);
            if (pingRequests != null && pingRequests.Count > 0)
            {
                return pingRequests.OrderByDescending(p => p.PingDate).FirstOrDefault();
            }
            else return new Models.VehiclePing() { PingStatus = PingStatus.Disconnected, VehicleId = vehicleId };

        }

        public async Task PersistPingInDbAsync(string id,int vehicleId,string vehicleIP,PingStatus pingStatus,DateTime pingDate)
        {
           await _vehiclePingRepository.AddPingAsync(new Models.VehiclePing() {Id=id,VehicleId=vehicleId,VehicleIP=vehicleIP,PingStatus=pingStatus,PingDate=pingDate });
        }
        public async Task<PingStatus> SendPingRequestAsync(string vehicleIP)
        {
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "pinging vehicle";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            var  pingStatus=PingStatus.Disconnected;
            _ping.SendAsync(vehicleIP, timeout, buffer, options);
            _ping.PingCompleted += (object sender, PingCompletedEventArgs e)=> {

                if (e.Reply.Status == IPStatus.Success)
                {
                    pingStatus= PingStatus.Connected;
                }
                else pingStatus= PingStatus.Disconnected;

            };

            return await Task.Run(()=>pingStatus);

        }

        
    }
}
