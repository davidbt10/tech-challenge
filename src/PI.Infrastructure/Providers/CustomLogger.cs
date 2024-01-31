using Microsoft.Extensions.Logging;
using PI.Application.Core.Models;

namespace PI.Infrastructure.Providers
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _configuration;

        public CustomLogger(string name, CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = name;
            _configuration = configuration;
        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = string.Format($"{logLevel}: {eventId} - {formatter(state, exception)}");
            Write(message);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        private void Write(string message)
        {
            var pathFile = @$"c:\fiap\LOG-{DateTime.Now:dd-MM-yyyy}.txt";
            if (!Path.Exists(pathFile) || !File.Exists(pathFile))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathFile));
                File.Create(pathFile).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(pathFile, true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
