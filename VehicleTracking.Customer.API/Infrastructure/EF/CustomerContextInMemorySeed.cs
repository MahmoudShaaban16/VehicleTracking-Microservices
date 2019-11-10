using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.Customer.API.Infrastructure.EF
{
    public class CustomerContextInMemorySeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustomerContext>>()))
            {
                
                if (context.Customers.Any())
                {
                    return;   // Data was already seeded
                }
                context.Customers.AddRange(
               new Models.Customer[] { new Models.Customer(){ Name = "Kalles Grustransporter AB ",Address = "Cementvägen 8, 111 11 Södertälje" },
                new Models.Customer(){ Name = "Johans Bulk AB ", Address = "Balkvägen 12, 222 22 Stockholm " },
               new Models.Customer(){ Name = "Haralds Värdetransporter AB", Address = "Budgetvägen 1, 333 33 Uppsala" }});
                context.SaveChanges();
            }
        }
    }


}
