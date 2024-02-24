using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace File.Service.Features.Items.ListItemStorages;

public sealed class ListItemStoragesHttpFunction(ILogger<ListItemStoragesHttpFunction> logger)
{
    private readonly ILogger<ListItemStoragesHttpFunction> _logger = logger;

    /// <summary>
    /// HTTP GET triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(ListItemStoragesHttpFunction))]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogHttpMessage();

        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
