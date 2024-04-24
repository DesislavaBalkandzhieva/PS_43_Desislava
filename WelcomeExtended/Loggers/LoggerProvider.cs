using Microsoft.Extensions.Logging;


namespace WelcomeExtended.Loggers
{
    internal class LoggerProvider : ILoggerProvider
    {
        ILogger ILoggerProvider.CreateLogger(string categoryName)
        {
           return new HashLogger(categoryName);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
