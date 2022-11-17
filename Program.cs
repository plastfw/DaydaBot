﻿using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Addons.Hosting;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

class Programm
{
  static async Task Main()
  {
    var builder = new HostBuilder()
      .ConfigureAppConfiguration(x =>
      {
        var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", false, true)
          .Build();

        x.AddConfiguration(configuration);
      })
      .ConfigureLogging(x =>
      {
        x.AddConsole();
        x.SetMinimumLevel(LogLevel.Debug);
      })
      .ConfigureDiscordHost((context, config) =>
      {
        config.SocketConfig = new DiscordSocketConfig()
        {
          LogLevel = LogSeverity.Debug,
          AlwaysDownloadUsers = false,
          MessageCacheSize = 200,
        };

        config.Token = context.Configuration["Token"];
      })
      .UseCommandService((context, config) =>
      {
        config.CaseSensitiveCommands = false;
        config.LogLevel = LogSeverity.Debug;
        config.DefaultRunMode = RunMode.Sync;
      })
      .ConfigureServices((context, services) =>
      {
        // services
        //   .AddHostedService<CommandAttribute>();
      })
      .UseConsoleLifetime();

    var host = builder.Build();
    using (host)
    {
      await host.RunAsync();
    }
  }
}