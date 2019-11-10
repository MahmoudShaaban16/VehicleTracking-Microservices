using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using VehicleTracking.Core;
using VehicleTracking.Core.RabbitMQ;
using VehicleTracking.Core.Services;
using VehicleTracking.Customer.API.Infrastructure.EF;

namespace VehicleTracking.Customer.API
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

        public static int Main(string[] args)
        {
            var configuration = GetConfiguration();

          

            try
            {
                 var host = BuildWebHost(configuration, args);
                
                // adding SQL db migration and db seed
                host.MigrateDbContext<CustomerContext>((context, services) =>
                {
                    var logger = (ILogger<CustomerContextSeed>)services.GetService(typeof(ILogger<CustomerContextSeed>));
                    new CustomerContextSeed()
                        .SeedAsync(context, logger)
                        .Wait();
                });
                // Adding Customers data seed for in memory database
                using (var scope = host.Services.CreateScope())
                {
                   
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<CustomerContext>();
                    CustomerContextInMemorySeed.Initialize(services);
                }



                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(false)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(configuration)
                
                .Build();

       

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            return builder.Build();
        }
    }
}

