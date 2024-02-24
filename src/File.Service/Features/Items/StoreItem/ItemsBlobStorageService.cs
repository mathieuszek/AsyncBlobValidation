using Azure.Storage.Blobs;

using File.Service.Commons;
using File.Service.Entities;
using File.Service.Settings;

using Microsoft.Extensions.Options;

namespace File.Service.Features.Items.StoreItem;

public sealed class ItemsBlobStorageService(BlobServiceClient blobServiceClient, IOptions<BlobStorageSettings> options) : IStoreItemService
{
    private readonly BlobServiceClient _blobServiceClient = blobServiceClient;
    private readonly BlobStorageSettings _options = options.Value;

    /// <inheritdoc/>
    public async Task<string> StoreAsync(Item data, CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(_options.ItemsContainerName);
        await containerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

        var storedPath = $"{PathGenerator.GenerateDateTimePathUpToMinutes(DateTime.UtcNow)}/{Guid.NewGuid()}.json";
        await containerClient.UploadBlobAsync(storedPath, BinaryData.FromObjectAsJson(data), cancellationToken: cancellationToken);

        return storedPath;
    }
}
