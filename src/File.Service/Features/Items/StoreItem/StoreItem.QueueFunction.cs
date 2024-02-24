using FluentValidation;

namespace File.Service.Features.Items.StoreItem;

public sealed class StoreItemQueueFunction(
    ILogger<StoreItemQueueFunction> logger,
    IMediator mediator,
    IValidator<StoreItemMessage> validator)
{
    private const string QueueTriggerName = "%InputMessageQueue%";

    private readonly ILogger<StoreItemQueueFunction> _logger = logger;
    private readonly IMediator _mediator = mediator;
    private readonly IValidator<StoreItemMessage> _validator = validator;

    /// <summary>
    /// Queue triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(StoreItemQueueFunction))]
    public async Task Run(
        [QueueTrigger(QueueTriggerName)] StoreItemMessage message,
        CancellationToken cancellationToken)
    {
        _logger.LogQueueMessage(message.ToString());

        if (await _validator.ValidateAsync(message, cancellation: cancellationToken) is { IsValid: false } validationError)
        {
            _logger.LogValidationErrors(validationError.Errors);
            return;
        }

        var command = new StoreItemCommand(message.Description);

        await _mediator.Send(command, cancellationToken: cancellationToken);
    }
}
