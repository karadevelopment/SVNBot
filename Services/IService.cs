using System.Threading.Tasks;

namespace SVNBot.Services
{
    public interface IService
    {
        Task StartAsync();
        Task StopAsync();
    }
}