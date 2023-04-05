using System;

enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string[] logLineParts = logLine.Split(':');
        string logLevelCode = logLineParts[0].Trim(new char[] {'[', ']'});
        
        LogLevel logLevel;
        switch (logLevelCode)
        {
            case "INF":
                logLevel = LogLevel.Info;
                break;
            case "DBG":
                logLevel = LogLevel.Debug;
                break;
            case "TRC":
                logLevel = LogLevel.Trace;
                break;
            case "WRN":
                logLevel = LogLevel.Warning;
                break;
            case "ERR":
                logLevel = LogLevel.Error;
                break;
            case "FTL":
                logLevel = LogLevel.Fatal;
                break;
            default:
                logLevel = LogLevel.Unknown;
                break;
        }

        return logLevel;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        string shortLog;
        switch (logLevel)
        {
            case LogLevel.Unknown:
                shortLog = $"0:{message}";
                break;
            case LogLevel.Trace:
                shortLog = $"1:{message}";
                break;
            case LogLevel.Debug:
                shortLog = $"2:{message}";
                break;
            case LogLevel.Info:
                shortLog = $"4:{message}";
                break;
            case LogLevel.Warning:
                shortLog = $"5:{message}";
                break;
            case LogLevel.Error:
                shortLog = $"6:{message}";
                break;
            case LogLevel.Fatal:
                shortLog = $"42:{message}";
                break;
            default:
                throw new ArgumentException();
        }
        
        return shortLog;
    }
}
