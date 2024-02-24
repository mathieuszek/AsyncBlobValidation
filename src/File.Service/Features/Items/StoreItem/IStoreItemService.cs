using File.Service.Entities;

namespace File.Service.Features.Items.StoreItem;

public interface IStoreItemService
{
    /// <summary>
    /// Stores <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Data to be stored.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Path to stored file.</returns>
    Task<string> StoreAsync(Item data, CancellationToken cancellationToken);
}