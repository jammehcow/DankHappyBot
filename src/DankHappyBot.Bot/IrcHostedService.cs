using System.Threading;
using System.Threading.Tasks;
using DankHappyBot.Service.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DankHappyBot.Bot
{
    public class IrcHostedService : BackgroundService
    {
        private readonly ILogger<IrcHostedService> _logger;

        private readonly IrcOptions _ircOptions;

        public IrcHostedService(ILogger<IrcHostedService> logger, IrcOptions ircOptions)
        {
            _logger = logger;
            _ircOptions = ircOptions;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // stub
        }
    }
}
