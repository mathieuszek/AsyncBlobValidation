namespace File.Service.Logs;

/// <summary>
/// Class with log messages.
/// </summary>
public static partial class LogMessages
{
    [LoggerMessage(Level = LogLevel.Information, Message = "C# HTTP trigger function processed a request.")]
    public static partial void LogHttpMessage(this ILogger logger);

    [LoggerMessage(Level = LogLevel.Information, Message = "C# Queue trigger function processed: {messageText}")]
    public static partial void LogQueueMessage(this ILogger logger, string messageText);
}
