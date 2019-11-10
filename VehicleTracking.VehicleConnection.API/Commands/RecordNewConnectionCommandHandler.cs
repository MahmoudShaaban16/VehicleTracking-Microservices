using MediatR;
using RawRabbit;
using System;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.VehicleConnection.API.Events;
using VehicleTracking.VehicleConnection.API.Repositories;

namespace VehicleTracking.VehicleConnection.API.Commands
{
    class RecordNewConnectionCommandHandler : IRequestHandler<RecordNewConnectionCommand, RecordNewConnectionCommandResult>
    {
        private readonly IVehicleConnectionRepository _vehicleConnectionRepository;
        private readonly IBusClient _busClient;
        public RecordNewConnectionCommandHandler(IVehicleConnectionRepository vehicleConnectionRepository,IBusClient busClient)
        {
            _vehicleConnectionRepository = vehicleConnectionRepository;
            _busClient = busClient;
        }
        public async Task<RecordNewConnectionCommandResult> Handle(RecordNewConnectionCommand request, CancellationToken cancellationToken)
        {
            await _vehicleConnectionRepository.AddVehicleConnectionAsync(new Models.VehicleConnection() { Id = Guid.NewGuid().ToString(), VehicleId = request.VehicleId, ConnectionDate = DateTime.Now });
            await _busClient.PublishAsync(new ConnectionSentByVehicleEvent() { DateCreated=DateTime.Now,Id=Guid.NewGuid(),VehicleId=request.VehicleId,VehicleIP=request.VehicleIP });
            return new RecordNewConnectionCommandResult();
        }
    }
}
