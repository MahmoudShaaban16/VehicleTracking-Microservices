using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace VehicleTracking.Vehicle.API.Infrastructure.EF
{
    public class VehicleContextSeed
    {
        public async Task SeedAsync(VehicleContext context, ILogger<VehicleContextSeed> logger)
        {
            context.Vehicles.AddRange(
                new Models.Vehicle[] { 
                new Models.Vehicle(){ VehicleNumber="YS2R4X20005399401", RegNumber = "ABC123",CustomerId=1 },
                new Models.Vehicle(){ VehicleNumber="VLUR4X20009093588", RegNumber = "DEF456",CustomerId=1 },
                new Models.Vehicle(){ VehicleNumber="VLUR4X20009048066", RegNumber = "GHI789",CustomerId=1 },
                new Models.Vehicle(){ VehicleNumber="YS2R4X20005388011", RegNumber = "JKL012",CustomerId=2 },
                new Models.Vehicle(){ VehicleNumber="YS2R4X20005387949", RegNumber = "MNO345",CustomerId=2 },
                new Models.Vehicle(){ VehicleNumber="VLUR4X20009048066", RegNumber = "PQR678",CustomerId=3 },
                new Models.Vehicle(){ VehicleNumber="YS2R4X20005387055", RegNumber = "STU901",CustomerId=3 },
                

                });
            context.SaveChanges();

        }
    }
}
