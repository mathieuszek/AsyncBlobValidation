namespace File.Service.Logs;

/// <summary>
/// Class with log messages.
/// </summary>
public static partial class LogMessages
{
    [LoggerMessage(Level = LogLevel.Warning, Message = "Validation Failed: {@validationFailure}.")]
    public static partial void LogValidationErrors(this ILogger logger, List<FluentValidation.Results.ValidationFailure>  validationFailure);
}
