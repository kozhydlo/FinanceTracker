using System;
using System.IO;

namespace FinanceTracker.Helpers
{
    public static class Logger
    {
        private static readonly string _logPath = "log.txt";

        public static void Log(string message)
        {
            File.AppendAllText(_logPath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
