using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using models = VehicleTracking.VehicleConnection.API.Models;
namespace VehicleTracking.VehicleConnection.API.Repositories
{
    public class VehicleConnectionRepository:IVehicleConnectionRepository
    {
        private Container _container;
        public VehicleConnectionRepository(CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddVehicleConnectionAsync(models.VehicleConnection vehicleConnection)
        {
            await this._container.CreateItemAsync<models.VehicleConnection>(vehicleConnection, new PartitionKey(vehicleConnection.Id));
        }
    }
}
