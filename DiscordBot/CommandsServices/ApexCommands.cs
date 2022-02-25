using Discord;
using Discord.Commands;
using DiscordBot.Models;
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
    public class ApexCommands : ModuleBase
    {
        [Command("Maps")]
        public async Task Maps()
        {
            try
            {
                MapRotation StatusResponse = JsonConvert.DeserializeObject<MapRotation>(ApexApi.GetData($"{ApexApi.Main_URL}{ApexApi.MapRotation}"));

                var builder = new EmbedBuilder()
                        .WithAuthor("BR Map:")
                        .WithColor(new Color(254, 130, 153))
                        .AddField("Map: ", $"{StatusResponse.battle_royale.current.map}", true)
                        .AddField("Time Duration: ", $"{StatusResponse.battle_royale.current.DurationInMinutes}", true)
                        .AddField("Time Remaining: ", $"{StatusResponse.battle_royale.current.remainingTimer}", true)
                        .AddField("Next Map: ", $"{StatusResponse.battle_royale.next.map}", true)
                        .AddField("Next Time Duration: ", $"{StatusResponse.battle_royale.next.DurationInMinutes}", true)
                        .AddField("Next Map Starts: ", $"{StatusResponse.battle_royale.current.remainingTimer}", true)
                        .WithImageUrl(StatusResponse.battle_royale.current.asset)
                        .WithFooter($"Created by 0xkaede")
                        .WithCurrentTimestamp();

                var result = builder.Build();

                await Context.Channel.SendMessageAsync(null, false, result);
            }
            catch (Exception ex)
            {
                Logs.Error($"CurrentMap command logged: Reason {ex}");
            }

        }
    }
}
