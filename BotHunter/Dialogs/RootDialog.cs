using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using AIMLbot;
using System.Web;
using BotHunter.App_Start;

namespace BotHunter.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {

            var activity = await result as Activity;

            string replyMessage;
            try
            {
                replyMessage = AimlBotSingleton.Chat(context.Activity.From, activity.Text);
            }
            catch (Exception ex)
            {
                replyMessage = ex.ToString();
            }

            await context.PostAsync(replyMessage);

            context.Wait(MessageReceivedAsync);
        }
    }
}