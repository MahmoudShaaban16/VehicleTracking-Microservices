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

        }
    }
}
