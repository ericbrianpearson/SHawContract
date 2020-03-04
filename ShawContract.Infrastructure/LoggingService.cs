using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CMS.EventLog;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;

namespace ShawContract.Infrastructure
{
    public class LoggingService : ILoggingService
    {
        public LoggingService()
        {
        }

        public void Log(LogLevel level, string message, string details, Exception ex = null)
        {
            Debug.WriteLine("Level: {0} , Message: {1}, Details {2}", level, message, details);

            if (level == LogLevel.Error)
            {
                EventLogProvider.LogException("ShawContract", "EXCEPTION", ex);
            }

        }

        public void Log(LogLevel level, string message, IEnumerable<BaseModel> collection, Exception ex = null)
        {
            StringBuilder strCollection = new StringBuilder();
            foreach (var item in collection)
            {
                strCollection.Append(item.ToString());
                strCollection.Append("||");
            }
            this.Log(level, message, strCollection.ToString(), ex);
        }

        private void LogInfo(string logText)
        {
            throw new NotImplementedException();
        }

        private void LogDebug(string logText)
        {
            throw new NotImplementedException();
        }

        private void LogWarning(string logText)
        {
            throw new NotImplementedException();
        }

        private void LogError(string logText)
        {
            throw new NotImplementedException();
        }
    }
}