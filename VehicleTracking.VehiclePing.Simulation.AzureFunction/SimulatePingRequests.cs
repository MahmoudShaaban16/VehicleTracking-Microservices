using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VehicleTracking.VehiclePing.Service.Models;
using VehicleTracking.VehiclePing.Service.Repositories;

namespace VehicleTracking.VehiclePing.Simulation.AzureFunction
{
    public static class SimulatePingRequests
    {
        [FunctionName("SimulatePingRequests")]
        public static async Task Run([TimerTrigger("0 */2 * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
        .SetBasePath(context.FunctionAppDirectory)
        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
            //reading CosmosDb settings from localsettings file
            var cosmosDbSettings = new CosmosDB.CosmosDbSetting();
            config.Bind("CosmosDb", cosmosDbSettings);
            // creating the vehicle ping service instance from the settings and initializing the repository
            try
            {
                var vehiclePingRepository = await InitializeCosmosClientInstanceAsync(cosmosDbSettings);
                VehiclePing.Service.Services.PingService pingService = new Service.Services.PingService(vehiclePingRepository);
                Random rnd = new Random();
                string vehicleIP = rnd.Next(20, 190).ToString() + "." + rnd.Next(20, 190).ToString() + "." + rnd.Next(1, 20).ToString() +"."+ rnd.Next(0, 10).ToString();
                int vehicleId = rnd.Next(1, 3);
                var pingStatus = rnd.Next(0, 1);
                pingService.PersistPingInDbAsync(Guid.NewGuid().ToString(), vehicleId, vehicleIP, (PingStatus)pingStatus, DateTime.Now);
            }
            catch(Exception ex)
            {
                log.LogError("An error while creating random vehicle ping request")
            }
            

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        private static async Task<VehiclePing.Service.Repositories.VehiclePingRepository> InitializeCosmosClientInstanceAsync(CosmosDB.CosmosDbSetting settings)
        {
            string databaseName = settings.DatabaseName;
            string containerName = settings.ContainerName;
            string account = settings.Account;
            string key = settings.Key;
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(account, key);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();
            VehiclePingRepository vehiclePingRepository = new VehiclePingRepository(client, databaseName, containerName);
            DatabaseResponse database =  await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return vehiclePingRepository;
        }
    }
}
