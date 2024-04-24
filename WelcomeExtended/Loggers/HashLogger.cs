using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger: ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        IDisposable? ILogger.BeginScope<TState>(TState state)
        {
            return null; //scopes are not supported
        }

        bool ILogger.IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            Console.ForegroundColor = logLevel switch
            {
                LogLevel.Critical => ConsoleColor.Red,
                LogLevel.Error => ConsoleColor.DarkRed,
                LogLevel.Warning => ConsoleColor.Yellow,
                _ => ConsoleColor.White,
            };

            var messagesToLog = new StringBuilder();
            messagesToLog.Append($"[{logLevel}]");
            messagesToLog.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messagesToLog);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }
    }
}
