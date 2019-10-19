using System;
using System.Threading.Tasks;

namespace SVNBot
{
    public class Program
    {
        private bool IsRunning { get; set; } = true;

        private Program()
        {
        }

        private async Task RunAsync()
        {
            await Startup.StartAsync();

            while (this.IsRunning)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "close":
                    case "exit":
                    case "stop":
                        this.IsRunning = false;
                        break;
                    default:
                        break;
                }
            }

            await Startup.StopAsync();
        }

        public static async Task Main(string[] args)
        {
            var instance = new Program();
            await instance.RunAsync();
        }
    }
}