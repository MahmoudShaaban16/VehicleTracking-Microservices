using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using VehicleTracking.Core.IntegrationEvents;

namespace VehicleTracking.Core.Services
{

    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;
        public IWebHost Webhost { get { return _webHost; } }
        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run() => _webHost.Run();

        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace;
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;
           
            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UseRabbitMq()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

                return new BusBuilder(_webHost, _bus);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }


        public class BusBuilder : BuilderBase
        {
            public IWebHost WebHost { get; set; }
            public IBusClient BusClient { get; set; }

            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                WebHost = webHost;
                BusClient = bus;
            }



            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHandler<TEvent>)WebHost.Services
                    .GetService(typeof(IEventHandler<TEvent>));
                BusClient.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(WebHost);
            }
        }
    }
}
