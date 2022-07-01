using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Microsoft.Extensions.Logging;

namespace Shiro
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public DiscordConfiguration Configuration { get; private set; }
        public CommandsNextConfiguration CommandsConfiguration { get; private set; }
        public CommandsNextExtension CommandsExtension { get; private set; }
        public InteractivityConfiguration InteractivityConfiguration { get; private set; }

        public Bot(Config config)
        {
            Configuration = new DiscordConfiguration()
            {
                Token = config.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                MinimumLogLevel = LogLevel.Debug,
            };

            CommandsConfiguration = new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { config.Prefix }
            };

            Client = new DiscordClient(Configuration);
            CommandsExtension = Client.UseCommandsNext(CommandsConfiguration);

            InteractivityConfiguration = new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2),
            };

            Client.UseInteractivity(InteractivityConfiguration);

            CommandsExtension.RegisterCommands<Commands>();
        }

        public async Task Run()
        {
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
