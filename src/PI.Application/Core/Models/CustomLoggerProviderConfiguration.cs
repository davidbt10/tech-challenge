using Microsoft.Extensions.Logging;

namespace PI.Application.Core.Models
{
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public int EventId { get; set; }
    }
}
