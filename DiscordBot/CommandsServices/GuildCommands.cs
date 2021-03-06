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
            SocketGuild guild = (SocketGuild)Context.Guild;

            string uRoles = "";

            string[] guildinfo = { 
                guild.Name, guild.IconUrl, 
                guild.OwnerId.ToString(), 
                guild.MemberCount.ToString(), 
                guild.MaxMembers.ToString()
            };

            string[] Nitroinfo = {
                guild.PremiumTier.ToString().Replace("Tier", ""),
                guild.PremiumSubscriptionCount.ToString(),
                null
            };

            string[] Channelsinfo = {
                guild.CategoryChannels.Count.ToString(),
                guild.TextChannels.Count.ToString(),
                guild.VoiceChannels.Count.ToString(),
            };


            if (Nitroinfo[0] == null || Nitroinfo[0] == "0")
                Nitroinfo[2] = "2";
            else if(Nitroinfo[0] == "1")
                Nitroinfo[2] = "15";
            else if(Nitroinfo[0] == "2")
                Nitroinfo[2] = "30";
            else if (Nitroinfo[0] == "3")
                Nitroinfo[2] = guildinfo[3];

            foreach (SocketRole role in guild.Roles)
            {
                if (!role.Name.ToLower().Contains("everyone"))
                {
                    uRoles += $"<@&{role.Id}> ".ToString();
                }
            }

            var builder = new EmbedBuilder()
                    .WithAuthor(guildinfo[0], guildinfo[1])
                    .WithThumbnailUrl(guildinfo[1])
                    .WithColor(new Color(254, 130, 153))

                    .AddField("Owner: ", $"<@{guildinfo[2]}>", true)
                    .AddField("Members: ", $"{guildinfo[3]}/{guildinfo[4]}", true)
                    .AddField("Boosts: ", $"Level {Nitroinfo[0]}\n{Nitroinfo[1]}/{Nitroinfo[2]} boosts", true)
                    .AddField("Channel Categories: ", $" {Channelsinfo[0]}", true)
                    .AddField("Text Channels: ", $" {guild.TextChannels.Count}", true)
                    .AddField("Voice Channelss: ", $" {guild.VoiceChannels.Count}", true)
                    .AddField($"Roles[{guild.Roles.Count}]: ", $"{uRoles}", true)

                    .WithFooter($"ID: {guild.Id.ToString()} | Server created: {guild.CreatedAt.ToString("MM/dd/yyyy")}")
                    .WithCurrentTimestamp();

            var result = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, result);

        }
    }
}
