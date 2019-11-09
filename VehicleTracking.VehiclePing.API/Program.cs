using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using VehicleTracking.Core;
using VehicleTracking.VehiclePing.API.Events;

namespace VehicleTracking.VehiclePing.API
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
                host.UseRabbitMq()
                .SubscribeToEvent<ConnectionSentByVehicleEvent>();
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
