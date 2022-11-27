using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Interactions;

namespace DiscordBotDadya.Modules
{
  public class PrefixModule : ModuleBase<SocketCommandContext>
  {
    [Command("ping")]
    public async Task HandlePingCommand()
    {
      Console.WriteLine("Prefix");
      await Context.Message.ReplyAsync("PING!");
    }
  }
}