using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Interactions;
using Discord.WebSocket;

namespace DiscordBotDadya
{
  public class InteractionHandler
  {
    private readonly DiscordSocketClient _client;
    private readonly InteractionService _commands;
    private readonly IServiceProvider _services;

    public InteractionHandler(DiscordSocketClient client, InteractionService commands, IServiceProvider services)
    {
      _client = client;
      _commands = commands;
      _services = services;
    }

    public async Task InitializeAsync()
    {
      await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

      _client.InteractionCreated += HandleInteraction;
    }

    private async Task HandleInteraction(SocketInteraction arg)
    {
      try
      {
        var ctx = new SocketInteractionContext(_client, arg);
        
        var result = await _commands.ExecuteCommandAsync(ctx, _services);

        if (!result.IsSuccess)
          switch (result.Error)
          {
            case InteractionCommandError.UnmetPrecondition:
              break;
            default:
              break;
          }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
  }
}