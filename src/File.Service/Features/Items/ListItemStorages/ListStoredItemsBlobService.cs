using System.Runtime.CompilerServices;

using Azure.Storage.Blobs;

using File.Service.Settings;

using Microsoft.Extensions.Options;

namespace File.Service.Features.Items.ListItemStorages;

public sealed class ListStoredItemsBlobService(BlobServiceClient blobServiceClient, IOptions<BlobStorageSettings> options) : IListStoredItemsService
{
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
    private readonly BlobStorageSettings _options = options.Value;

    /// <inheritdoc/>
    public async IAsyncEnumerable<string> ListAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_options.ItemsContainerName);

        await foreach (var page in containerClient.GetBlobsAsync(cancellationToken: cancellationToken))
        {
            yield return page.Name;
        }
    }
}
