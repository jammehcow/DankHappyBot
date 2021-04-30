using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DankHappyBot.Bot
{
    public class IrcHostedService : BackgroundService
    {
        private readonly ILogger<IrcHostedService> _logger;

        public IrcHostedService(ILogger<IrcHostedService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // stub
        }
    }
}
