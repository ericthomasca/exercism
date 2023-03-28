using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        var logLineArray = logLine.Split(':');
        return logLineArray[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        var logLineArray = logLine.Split(':');
        return logLineArray[0].Trim('[', ']', ' ').ToLower();
    }

    public static string Reformat(string logLine)
    {
        var logLevel = LogLevel(logLine);
        var message = Message(logLine);

        return String.Format("{0} ({1})", message, logLevel);



    }
}
