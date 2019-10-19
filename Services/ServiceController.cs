using System.Collections.Generic;
using System.Threading.Tasks;

namespace SVNBot.Services
{
    public class ServiceController
    {
        private List<IService> Services { get; } = new List<IService>();

        public ServiceController()
        {
        }

        public void Add<T>()
            where T : IService, new()
        {
            var service = new T();
            this.Services.Add(service);
        }

        public async Task StartAsync()
        {
            foreach (var service in this.Services)
            {
                await service.StartAsync();
            }
        }

        public async Task StopAsync()
        {
            foreach (var service in this.Services)
            {
                await service.StopAsync();
            }
        }
    }
}