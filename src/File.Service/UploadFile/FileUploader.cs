using Azure.Storage.Queues.Models;

namespace File.Service.UploadFile;

public sealed class FileUploader(ILogger<FileUploader> logger)
{
    private const string QueueTriggerName = "%InputMessageQueue%";

    private readonly ILogger<FileUploader> _logger = logger;

    /// <summary>
    /// Queue triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(FileUploader))]
    public void Run([QueueTrigger(QueueTriggerName)] QueueMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _logger.LogQueueMessage(message.MessageText);
    }
}
