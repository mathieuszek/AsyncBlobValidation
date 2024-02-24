using Azure.Storage.Queues.Models;

using MediatR;

namespace File.Service.Features.Items.StoreItem;

public sealed class StoreItemQueueFunction(ILogger<StoreItemQueueFunction> logger, IMediator mediator)
{
    private const string QueueTriggerName = "%InputMessageQueue%";

    private readonly ILogger<StoreItemQueueFunction> _logger = logger;
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Queue triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(StoreItemQueueFunction))]
    public async Task Run([QueueTrigger(QueueTriggerName)] QueueMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _logger.LogQueueMessage(message.MessageText);

        var command = new StoreItemCommand(message.MessageText);
        await _mediator.Send(command);
    }
}
