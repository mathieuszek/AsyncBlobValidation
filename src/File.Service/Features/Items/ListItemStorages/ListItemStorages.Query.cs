namespace File.Service.Features.Items.ListItemStorages;

/// <summary>
/// Lists stored Items paths.
/// </summary>
/// <param name="Description"></param>
public sealed record ListItemStoragesQuery() : IStreamRequest<string>;
