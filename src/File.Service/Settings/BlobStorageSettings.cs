namespace File.Service.Settings;

public sealed class BlobStorageSettings
{
    public const string SettingsKey = "BlobStorage";

    /// <summary>
    /// Stores name of the container where 'Items' are stored.
    /// </summary>
    public required string ItemsContainerName { get; init; }
}
