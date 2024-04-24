using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());
            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
