using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    class StartupService
    {
        private static IServiceProvider _prividor;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly IConfigurationRoot _config;

        public StartupService(IServiceProvider provider, DiscordSocketClient discord, CommandService commands, IConfigurationRoot config)
        {
            _prividor = provider;
            _config = config;
            _discord = discord;
            _commands = commands;
        }

        public async Task StartAsync()
        {
            string token = _config["discordtoken"];
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Please enter in your token");
                return;
            }

            string ApexApiKey = _config["ApexApiKey"];
            if (string.IsNullOrWhiteSpace(ApexApiKey))
            {
                Console.WriteLine("Please enter in your ApexApiKey");
                return;
            }

            string FortniteApiKey = _config["FortniteApiKey"];
            if (string.IsNullOrWhiteSpace(FortniteApiKey))
            {
                Console.WriteLine("Please enter in your FortniteApiKey");
                return;
            }

            //Tempo
            File.WriteAllText(Path.GetTempPath() + "SALKDH891.KAEDE", ApexApiKey);
            File.WriteAllText(Path.GetTempPath() + "SALKDH892.KAEDE", FortniteApiKey);

            await _discord.LoginAsync(TokenType.Bot, token);
            await _discord.StartAsync();

            await _discord.SetActivityAsync(new Game("Created by 0xkaede", ActivityType.CustomStatus, ActivityProperties.None)).ConfigureAwait(false);
            await _commands.AddModulesAsync(Assembly.GetExecutingAssembly(), _prividor);
        }
    }
}
