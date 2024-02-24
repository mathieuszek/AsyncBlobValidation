using Azure.Storage.Queues.Models;

namespace File.Service.Features.Items.StoreItem;

public sealed class StoreItemQueueFunction(ILogger<StoreItemQueueFunction> logger)
{
    private const string QueueTriggerName = "%InputMessageQueue%";

    private readonly ILogger<StoreItemQueueFunction> _logger = logger;

    /// <summary>
    /// Queue triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(StoreItemQueueFunction))]
    public void Run([QueueTrigger(QueueTriggerName)] QueueMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _logger.LogQueueMessage(message.MessageText);
    }
}
