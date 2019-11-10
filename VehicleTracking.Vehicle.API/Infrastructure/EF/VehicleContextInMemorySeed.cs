using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.Vehicle.API.Infrastructure.EF
{
    public class VehicleContextInMemorySeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VehicleContext(
                serviceProvider.GetRequiredService<DbContextOptions<VehicleContext>>()))
            {
                
                if (context.Vehicles.Any())
                {
                    return;   // Data was already seeded
                }
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


}
