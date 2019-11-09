using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace VehicleTracking.Customer.API.Infrastructure.EF
{
    public class CustomerContextSeed
    {
        public async Task SeedAsync(CustomerContext context, ILogger<CustomerContextSeed> logger)
        {
            context.Customers.AddRange(
                new Models.Customer[] { new Models.Customer(){ Name = "Kalles Grustransporter AB ",Address = "Cementvägen 8, 111 11 Södertälje" },
                new Models.Customer(){ Name = "Johans Bulk AB ", Address = "Balkvägen 12, 222 22 Stockholm " },
               new Models.Customer(){ Name = "Haralds Värdetransporter AB", Address = "Budgetvägen 1, 333 33 Uppsala" }});
            context.SaveChanges();

        }
    }
}
