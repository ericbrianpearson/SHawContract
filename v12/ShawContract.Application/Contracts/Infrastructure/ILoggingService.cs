using System;
using System.Collections.Generic;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Infrastructure
{
    public enum LogLevel
    {
        Info,
        Debug,
        Warning,
        Error
    }

    public interface ILoggingService
    {
        void Log(LogLevel level, string message, string details, Exception ex = null);

        void Log(LogLevel level, string message, IEnumerable<BaseModel> collection, Exception ex = null);
    }
}