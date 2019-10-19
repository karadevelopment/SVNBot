using Discord;
using Discord.Commands;
using Discord.WebSocket;
using SVNBot.Constants;
using System;
using System.Threading.Tasks;

namespace SVNBot.Services
{
    public class DiscordService : IService
    {
        private DiscordSocketClient Client { get; }

        public DiscordService()
        {
            var config = new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 1000,
            };
            this.Client = new DiscordSocketClient(config);
            this.Client.MessageReceived += this.OnMessageReceivedAsync;
        }

        public async Task StartAsync()
        {
            await this.Client.LoginAsync(TokenType.Bot, DiscordConstants.TOKEN);
            await this.Client.StartAsync();
        }

        public async Task StopAsync()
        {
            await this.Client.LogoutAsync();
            await this.Client.StopAsync();
        }

        private async Task OnMessageReceivedAsync(SocketMessage message)
        {
            if (message is SocketUserMessage userMessage && userMessage.Author.Id != this.Client.CurrentUser.Id)
            {
                var context = new SocketCommandContext(this.Client, userMessage);
                Console.WriteLine(userMessage.Author);
                Console.WriteLine(userMessage.Channel);
                Console.WriteLine(userMessage.Content);
                await context.Channel.SendMessageAsync($"conent: {userMessage.Content}");
            }
        }
    }
}