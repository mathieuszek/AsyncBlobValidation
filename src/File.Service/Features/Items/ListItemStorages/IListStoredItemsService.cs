namespace File.Service.Features.Items.ListItemStorages;

public interface IListStoredItemsService
{
    /// <summary>
    /// Returns all stored item paths.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Stored file paths list.</returns>
    IAsyncEnumerable<string> ListAsync(CancellationToken cancellationToken);
}
