using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using models = VehicleTracking.VehiclePing.Service.Models;
namespace VehicleTracking.VehiclePing.Service.Repositories
{
    public class VehiclePingRepository : IVehiclePingRepository
    {
        private Container _container;
        public VehiclePingRepository(CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddPingAsync(models.VehiclePing pingRequest)
        {
            await this._container.CreateItemAsync<models.VehiclePing>(pingRequest, new PartitionKey(pingRequest.Id));
        }



        public async Task<List<models.VehiclePing>> GetByAsync(int vehicleId)
        {
            var query = this._container.GetItemQueryIterator<models.VehiclePing>(new QueryDefinition($" SELECT * FROM c where vehicleId={vehicleId}"));
            List<models.VehiclePing> results = new List<models.VehiclePing>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
