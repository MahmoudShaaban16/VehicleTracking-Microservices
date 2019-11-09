using System.Threading.Tasks;

namespace VehicleTracking.Core.IntegrationEvents
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
