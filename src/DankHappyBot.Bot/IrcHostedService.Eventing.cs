using System.Threading.Tasks;
using GravyIrc;
using GravyIrc.Messages;
using Microsoft.Extensions.Logging;

namespace DankHappyBot.Bot
{
    public partial class IrcHostedService
    {
        public async Task OnPrivateMessageReceived(IrcMessageEventArgs<PrivateMessage> message)
        {
            _logger.LogInformation("Got PRIVMSG from user {Username} with content: {Content}", message.IrcMessage.From,
                message.IrcMessage.Message);
        }
    }
}
