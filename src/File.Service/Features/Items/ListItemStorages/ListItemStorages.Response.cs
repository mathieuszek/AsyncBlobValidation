namespace File.Service.Features.Items.ListItemStorages;

/// <summary>
/// .Represents ListItemStorages response returned to client.
/// </summary>
/// <param name="Path">Item storage path.</param>
public sealed record ListItemStoragesResponse(string Path);
