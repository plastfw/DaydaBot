using System;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;

namespace DiscordBotDadya.Modules
{
  public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
  {
    [SlashCommand("ping", "Receive a ping message")]
    public async Task HandlePingCommand()
    {
      Console.WriteLine("Slash");
      await RespondAsync("PING!");
    }

    [SlashCommand("components", "Buttons")]
    public async Task HandleComponentCommand()
    {
      var button = new ButtonBuilder()
      {
        Label = "Button!",
        CustomId = "button",
        Style = ButtonStyle.Primary
      };

      var menu = new SelectMenuBuilder()
      {
        CustomId = "menu",
        Placeholder = "Sample Menu"
      };
      menu.AddOption("First Option", "first");
      menu.AddOption("Second Option", "second");

      var component = new ComponentBuilder();
      component.WithButton(button);
      component.WithSelectMenu(menu);

      await RespondAsync("testing", components: component.Build());
    }

    [ComponentInteraction("button")]
    public async Task HandleButtonInput()
    {
      await RespondWithModalAsync<DemoModal>("demo_modal");
    }

    [ComponentInteraction("menu")]
    public async Task HandleSelection(string[] inputs)
    {
      await RespondAsync(inputs[0]);
    }

    [ModalInteraction("demo_modal")]
    public async Task HandleModalInput(DemoModal modal)
    {
      string input = modal.Greeting;
      await ReplyAsync(input);
    }
  }

  public class DemoModal : IModal
  {
    public string Title => "Demo Modal";

    [InputLabel("Send a greeting!")]
    [ModalTextInput("greeting_input", TextInputStyle.Short, placeholder: "Be nice...", maxLength: 100)]
    public string Greeting { get; set; }
  }
}