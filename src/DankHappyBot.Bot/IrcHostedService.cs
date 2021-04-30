using System.Threading;
using System.Threading.Tasks;
using DankHappyBot.Service.Configuration;
using GravyIrc;
using GravyIrc.Connection;
using GravyIrc.Messages;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DankHappyBot.Bot
{
    public partial class IrcHostedService : BackgroundService
    {
        private readonly ILogger<IrcHostedService> _logger;

        private readonly IrcOptions _ircOptions;

        private IrcClient IrcClient { get; set; }

        public IrcHostedService(ILogger<IrcHostedService> logger, IrcOptions ircOptions)
        {
            _logger = logger;
            _ircOptions = ircOptions;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting IRC client with username {Username}", _ircOptions.Credentials.Username);

            var ircUser = new User(_ircOptions.Credentials.Username);

            // TODO: move TcpClientConnection to factory
            IrcClient = new IrcClient(ircUser, _ircOptions.Credentials.OAuthToken, new TcpClientConnection());

            IrcClient.EventHub.Subscribe<PrivateMessage>(async (_, pm) => await OnPrivateMessageReceived(pm));
            await IrcClient.ConnectAsync(_ircOptions.Connection.Address, _ircOptions.Connection.Port);

            // Wait until cancelled
            // TODO: allow for managed cancel instead of relying on console kill
            await Task.Delay(-1, stoppingToken);

            _logger.LogInformation("Stopping IRC client");
        }

        public override void Dispose()
        {
            IrcClient?.Dispose();
        }
    }
}
