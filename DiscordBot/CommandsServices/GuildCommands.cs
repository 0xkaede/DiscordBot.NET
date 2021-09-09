using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.CommandsServices
{
    public class GuildCommands : ModuleBase
    {
        [Command("serverinfo")]
        public async Task serverinfo()
        {
            //TODO: Finish this shit!

            SocketGuild guild = (SocketGuild)Context.Guild;

            var builder = new EmbedBuilder()
                    .WithAuthor(guild.Name, guild.IconUrl)
                    .WithThumbnailUrl(guild.IconUrl)
                    .WithColor(new Color(254, 130, 153))

                    .AddField("Owner: ", $"<@{guild.OwnerId}>", true)
                    .AddField("Channel Categories", "", false)
                    .AddField("Text Channels", guild.Channels.Count, false)
                    .AddField("Voice Channels", guild.VoiceChannels, false)
                    .AddField("Members", $"{guild.MemberCount}/{guild.MaxMembers}", false)

                    .WithFooter($"ID: {guild.Id.ToString()} | Server created: {guild.CreatedAt.ToString("MM/dd/yyyy")}")
                    .WithCurrentTimestamp();

            var result = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, result);

        }
    }
}
