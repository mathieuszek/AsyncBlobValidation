using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace File.Service.UploadFile;

public sealed class ListBlobsHttpFunction(ILogger<ListBlobsHttpFunction> logger)
{
    private readonly ILogger<ListBlobsHttpFunction> _logger = logger;

    /// <summary>
    /// HTTP GET triggered by any incoming message passed to <see cref="QueueTriggerName"/>.
    /// Function prints incoming <paramref name="message"/>.
    /// </summary>
    /// <param name="message">Message with data.</param>
    [Function(nameof(ListBlobsHttpFunction))]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogHttpMessage();

        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
