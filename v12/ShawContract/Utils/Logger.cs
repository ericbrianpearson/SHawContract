using ShawContract.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShawContract.Utils
{
    public class Logger
    {
        public ILoggingService LoggingService { get; }

        public Logger(ILoggingService loggingService)
        {
            LoggingService = loggingService;
        }

        public void LogError(Exception error)
        {
            LoggingService.Log(LogLevel.Error, error.Message, error.ToString());
        }
    }
}