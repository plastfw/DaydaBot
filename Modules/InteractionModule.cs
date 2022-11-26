using System.Threading.Tasks;
using Discord.Interactions;

namespace DiscordBotDadya.Modules
{
  public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
  {
    [SlashCommand("chel", "Receive a ping message")]
    public async Task HandlePingCommand()
    {
      await RespondAsync("PING!");
    }
  }
}