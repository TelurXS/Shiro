using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;

namespace Shiro
{
    public class Commands : BaseCommandModule
    {
        [Command("greet")]
        public async Task Greet(CommandContext ctx)
        {
            await ctx.RespondAsync("Greetings! Thank you for executing me!");
        }

        [Command("say")]
        public async Task Say(CommandContext ctx, params string[] messages) 
        {
            await ctx.Message.DeleteAsync().ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(string.Join(' ', messages)).ConfigureAwait(false);
        }

        [Command("responce")]
        public async Task Responce(CommandContext ctx) 
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
            
            await ctx.Channel.SendMessageAsync(message.Result.Content).ConfigureAwait(false);

            await ctx.Message.DeleteAsync().ConfigureAwait(false);
        }

        [Command("tobigtext")]
        public async Task ToBigText(CommandContext ctx, params string[] messages) 
        {
            var interactivity = ctx.Client.GetInteractivity();

            string text = string.Join(' ', messages);
            string bigText = string.Empty;

            foreach (char item in text)
            {
                if (char.IsLetter(item))
                {
                    bigText += $":regional_indicator_{char.ToLower(item)}:";
                }
                else bigText += item;
            }

            await ctx.Channel.SendMessageAsync(bigText).ConfigureAwait(false);
            await ctx.Message.DeleteAsync().ConfigureAwait(false);
        }
    }
}
