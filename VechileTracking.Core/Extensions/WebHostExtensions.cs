using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using VehicleTracking.Core.IntegrationEvents;
using VehicleTracking.Core.RabbitMQ;
using static VehicleTracking.Core.Services.ServiceHost;

namespace VehicleTracking.Core
{
    public static class WebHostExtensions
    {
        public static BusBuilder  UseRabbitMq(this IWebHost webHost)
        {
           var _bus = (IBusClient)webHost.Services.GetService(typeof(IBusClient));

            return new BusBuilder(webHost, _bus);
        }
        public static IWebHost  SubscribeToEvent<TEvent>(this BusBuilder busBuilder) where TEvent : IEvent
        {
            var handler = (IEventHandler<TEvent>)busBuilder.WebHost.Services
                .GetService(typeof(IEventHandler<TEvent>));
            busBuilder.BusClient.WithEventHandlerAsync(handler);

            return busBuilder.Build().Webhost;
        }
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {

            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();

                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Migrating database associated with the context {DbContextName}", typeof(TContext).Name);


                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

                }
            }

            return webHost;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            
            context.Database.Migrate();
            seeder(context, services);
        }


        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg => 
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }
    }
}