using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SVNBot.Services;
using System.Threading.Tasks;

namespace SVNBot
{
    public class Startup
    {
        private static Startup Instance { get; }
        private IConfigurationRoot Configuration { get; }
        private ServiceController ServiceController { get; set; }

        static Startup()
        {
            Startup.Instance = new Startup();
        }

        private Startup()
        {
            var builder = new ConfigurationBuilder();
            var build = builder.Build();
            this.Configuration = build;

            this.ServiceController = new ServiceController();
            this.ServiceController.Add<DiscordService>();

            var services = new ServiceCollection();
            services.AddSingleton(this.Configuration);
            services.AddSingleton(this.ServiceController);
        }

        public static async Task StartAsync()
        {
            var instance = Startup.Instance;
            var controller = instance.ServiceController;
            await controller.StartAsync();
        }

        public static async Task StopAsync()
        {
            var instance = Startup.Instance;
            var controller = instance.ServiceController;
            await controller.StopAsync();
        }
    }
}