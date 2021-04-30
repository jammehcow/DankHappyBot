using System;
using DankHappyBot.Service.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DankHappyBot.Bot.Extension
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration<TOptions>(this IServiceCollection services)
            where TOptions : class, IPrefixedOptions, new() =>
            services.AddScoped(provider =>
            {
                var config = provider.GetService<IConfiguration>();

                if (config == null)
                    throw new ArgumentException("No IConfiguration was registered in the ServiceCollection");

                TOptions options = new();
                config.GetSection(options.GetPrefix()).Bind(options);

                return options;
            });
    }
}
