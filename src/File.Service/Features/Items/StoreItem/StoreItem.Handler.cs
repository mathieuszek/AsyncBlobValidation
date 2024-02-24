using File.Service.Commons;
using File.Service.Entities;

namespace File.Service.Features.Items.StoreItem;

public sealed class StoreItemHandler(IStoreItemService storageService) : ICommandHandler<StoreItemCommand, Result>
{
    private readonly IStoreItemService _storageService = storageService;

    /// <summary>
    /// Stores Item.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Newly stored item item id.</returns>
    public async Task<Result> Handle(StoreItemCommand request, CancellationToken cancellationToken)
    {
        var item = new Item(request.Description);

        await _storageService.StoreAsync(item, cancellationToken: cancellationToken);

        return Result.Success();
    }
}