namespace File.Service.Features.Items.ListItemStorages;

public sealed class ListItemStoragesHandler(IListStoredItemsService listStoredItemsService) : IStreamRequestHandler<ListItemStoragesQuery, string>
{
    private readonly IListStoredItemsService _listStoredItemsService = listStoredItemsService;

    /// <summary>
    /// List stored items path.
    /// </summary>
    /// <param name="request">Request</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Stored items path.</returns>
    public IAsyncEnumerable<string> Handle(ListItemStoragesQuery request, CancellationToken cancellationToken)
        => _listStoredItemsService.ListAsync(cancellationToken: cancellationToken);
}
