using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.CommandsServices
{
    public class UsersCommands : ModuleBase
    {
        [Command("userinfo")]
        public async Task info(SocketGuildUser user = null)
        {
            string uRoles = "";
            int rolesnum = 0;

            if (user == null)
            {
                foreach (SocketRole role in ((SocketGuildUser)Context.Message.Author).Roles)
                {
                    if (!role.Name.ToLower().Contains("everyone"))
                    {
                        rolesnum++;
                        uRoles += $"<@&{role.Id}> ".ToString();
                    }
                }

                var builder = new EmbedBuilder()
                    .WithAuthor($"{Context.User.Username}#{Context.User.Discriminator}", Context.User.GetAvatarUrl())
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithDescription($"Here some information about <@{Context.User.Id}>")
                    .WithColor(new Color(254, 130, 153))

                    .AddField("Created at: ", Context.User.CreatedAt.ToString("ddd, MMM dd, yyyy"), true)
                    .AddField("Joined on: ", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("ddd, MMM dd, yyyy"), true)
                    .AddField($"Roles [{rolesnum}]: ", uRoles, false)

                    .WithCurrentTimestamp();

                var result = builder.Build();


                await Context.Channel.SendMessageAsync(null, false, result);
            }
            else
            {
                foreach (SocketRole role in user.Roles)
                {
                    if (!role.Name.ToLower().Contains("everyone"))
                    {
                        rolesnum++;
                        uRoles += $"<@&{role.Id}> ".ToString();
                    }
                }

                var builder = new EmbedBuilder()
                    .WithAuthor($"{user.Username}#{user.Discriminator}", user.GetAvatarUrl())
                    .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())    
                    .WithDescription($"Here some information about <@{user.Id}>")
                    .WithColor(new Color(254, 130, 153))

                    .AddField("Created at: ", user.CreatedAt.ToString("ddd, MMM dd, yyyy"), true)
                    .AddField("Joined on: ", user.JoinedAt.Value.ToString("ddd, MMM dd, yyyy"), true)
                    .AddField($"Roles [{rolesnum}]: ", uRoles, false)
                    .AddField($"Roles [{rolesnum}]: ", uRoles, false)
                    .WithCurrentTimestamp();

                var result = builder.Build();


                await Context.Channel.SendMessageAsync(null, false, result);
            }
            

            rolesnum = 0;
        }
    }
}
