using Discord;
using Discord.Commands;
using DiscordBot.Models;
using DiscordBot.Models.FortniteApi;
using DiscordBot.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot.CommandsServices
{
    public class FortniteCommands : ModuleBase
    {
        [Command("FnStats")]
        public async Task FnStats(params string[] name)
        {
            try
            {
                Main StatusResponse = JsonConvert.DeserializeObject<Main>(FortniteApi.GetStats(string.Join("%20", name)));

                var builder = new EmbedBuilder()
                        .WithAuthor("Fortnite Stats:")
                        .WithColor(new Color(254, 130, 153))
                        .AddField("Account Name: ", $"{StatusResponse.data.account.name}", true)
                        .AddField("battlePass Level: ", $"{StatusResponse.data.battlePass.level}", true)
                        .AddField("battlePass progress: ", $"{StatusResponse.data.battlePass.progress}", true)
                        .AddField("Account ID: ", $"{StatusResponse.data.account.id}", true)
                        .WithImageUrl(StatusResponse.data.image)
                        .WithFooter($"Created by 0xkaede")
                        .WithCurrentTimestamp();

                var result = builder.Build();

                await Context.Channel.SendMessageAsync(null, false, result);
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync("Account not found.", false);
                Logs.Error($"CreatorCode command logged. Reason: Account not found.");
            }
        }

        [Command("CreatorCode")]
        public async Task CreatorCode(params string[] name)
        {
            try
            {
                Main StatusResponse = JsonConvert.DeserializeObject<Main>(FortniteApi.GetCreatorCode(string.Join("%20", name)));

                var builder = new EmbedBuilder()
                        .WithAuthor("Creator Code:")
                        .WithColor(new Color(254, 130, 153))
                        .AddField("Creator Code: ", $"{StatusResponse.data.code}", true)
                        .AddField("Status: ", $"{StatusResponse.data.status}", true)
                        .AddField("Verified: ", $"{StatusResponse.data.verified}", true)
                        .AddField("Account Name: ", $"{StatusResponse.data.account.name}", true)
                        .AddField("Account ID: ", $"{StatusResponse.data.account.id}", true)
                        .WithImageUrl(StatusResponse.data.image)
                        .WithFooter($"Created by 0xkaede")
                        .WithCurrentTimestamp();

                var result = builder.Build();

                await Context.Channel.SendMessageAsync(null, false, result);
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync("Creator Code not found.", false);
                Logs.Error($"CreatorCode command logged. Reason: Creator Code not found.");
            }
        }

        [Command("News")]
        public async Task News()
        {
            try
            {
                Main StatusResponse = JsonConvert.DeserializeObject<Main>(FortniteApi.GetNews());

                var builder = new EmbedBuilder()
                        .WithAuthor("Fortnite News: ")
                        .WithColor(new Color(254, 130, 153))
                        .WithImageUrl(StatusResponse.data.image)
                        .WithFooter($"Created by 0xkaede")
                        .WithCurrentTimestamp();

                var result = builder.Build();

                await Context.Channel.SendMessageAsync(null, false, result);
            }
            catch (Exception)
            {

            }
        }

        [Command("Map")]
        public async Task Map()
        {
            try
            {
                Main StatusResponse = JsonConvert.DeserializeObject<Main>(FortniteApi.GetMap());

                var builder = new EmbedBuilder()
                        .WithAuthor("Fortnite Map: ")
                        .WithColor(new Color(254, 130, 153))
                        .WithImageUrl(StatusResponse.data.images.pois)
                        .WithFooter($"Created by 0xkaede")
                        .WithCurrentTimestamp();

                var result = builder.Build();

                await Context.Channel.SendMessageAsync(null, false, result);
            }
            catch (Exception)
            {

            }
        }
    }
}
