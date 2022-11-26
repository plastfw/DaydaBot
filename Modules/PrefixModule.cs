using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace DiscordBotDadya.Modules
{
  public class PrefixModule : ModuleBase<SocketCommandContext>
  {
    [Command("ping")]
    public async Task HandlePingCommand()
    {
      await Context.Message.ReplyAsync("PING!");
    }
  }
}