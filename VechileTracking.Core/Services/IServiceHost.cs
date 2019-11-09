using Microsoft.AspNetCore.Hosting;

namespace VehicleTracking.Core.Services
{
    public interface IServiceHost
    {
        IWebHost Webhost { get; }
        void Run();
    }
}
