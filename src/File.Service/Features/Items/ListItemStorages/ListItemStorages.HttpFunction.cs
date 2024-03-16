using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace File.Service.Features.Items.ListItemStorages;

public sealed class ListItemStoragesHttpFunction(ILogger<ListItemStoragesHttpFunction> logger, IMediator mediator)
{
    private readonly ILogger<ListItemStoragesHttpFunction> _logger = logger;
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// HTTP GET triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(ListItemStoragesHttpFunction))]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
        [FromQuery] ListItemStoragesQuery query,
        CancellationToken cancellationToken)
    {
        _logger.LogHttpMessage();

        var resultItems = new List<ListItemStoragesResponse>();
        await foreach (var item in _mediator.CreateStream(query, cancellationToken: cancellationToken))
        {
            resultItems.Add(new(item));
        }

        return new OkObjectResult(resultItems);
    }
}
