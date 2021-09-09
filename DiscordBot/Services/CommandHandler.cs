using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Services
{
    public class CommandHandler
    {
        private static IServiceProvider _prividor;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly IConfigurationRoot _config;

        public CommandHandler(DiscordSocketClient discord, CommandService commands, IConfigurationRoot config, IServiceProvider provider) 
        {
            _prividor = provider;
            _config = config;
            _discord = discord;
            _commands = commands;

            _discord.Ready += OnReady;
            _discord.MessageReceived += OnMessageRecived;
        }

        private async Task OnMessageRecived(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;

            //if (msg.Author.IsBot) return;
            var context = new SocketCommandContext(_discord, msg);

            int pos = 0;
            if(msg.HasStringPrefix(_config["prefix"], ref pos) || msg.HasMentionPrefix(_discord.CurrentUser, ref pos))
            {
                var usercommand = context.User.Username + "#" + context.User.Discriminator;
                var result = await _commands.ExecuteAsync(context, pos, _prividor);
                if (!result.IsSuccess)
                {
                    var reason = result.Error;

                    await context.Channel.SendMessageAsync($"The following error occured: \n {reason}");

                    Logs.Error($"The following error occured from an executed command from {usercommand}: {reason}");
                }
                Logs.CommandSent($"{usercommand}: Just executed an command");
            }

        }

        private Task OnReady()
        {
            Random random= new Random();
            var TOKEN = _config["discordtoken"].GetLast(18);
            Logs.Info($"Discord bot created in Discord.NET, by 0xkaede");
            Logs.Info($"Connected as username: {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");
            Logs.Info($"Connected as ID: {_discord.CurrentUser.Id}");
            Logs.Info($"Bot using Token that ends with: {TOKEN}");
            Logs.Info($"Bot is currently in {_discord.Guilds.Count} Guild");

            foreach (var guild in _discord.Guilds)
            {
                string[] guildinfo = { guild.Name, guild.DefaultChannel.CreateInviteAsync().Result.ToString() }; 

                Logs.Guilds($"{guildinfo[0]} | {guildinfo[1]}");
            }
            //Console.WriteLine($"Connected as {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");
            return Task.CompletedTask;
        }
    }
}
