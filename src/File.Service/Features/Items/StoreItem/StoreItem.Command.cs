using File.Service.Commons;

namespace File.Service.Features.Items.StoreItem;

/// <summary>
/// Stores Item.
/// </summary>
/// <param name="Description"></param>
public sealed record StoreItemCommand(string Description) : ICommand<Result>;
