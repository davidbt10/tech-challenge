using Microsoft.Extensions.Logging;
using PI.Application.Core.Models;
using System.Collections.Concurrent;

namespace PI.Infrastructure.Providers
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration _loggerConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> _loggers;

        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerConfig = loggerConfig;
            _loggers = new ConcurrentDictionary<string, CustomLogger>();
        }

        public ILogger CreateLogger(string category)
        {
            return _loggers.GetOrAdd(category, name => new CustomLogger(name, _loggerConfig));
        }

        public void Dispose()
        { }
    }
}
