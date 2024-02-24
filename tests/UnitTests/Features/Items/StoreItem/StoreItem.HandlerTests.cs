using File.Service.Entities;
using File.Service.Features.Items.StoreItem;

using NSubstitute;

namespace UnitTests.Features.Items.StoreItem;

public class StoreItemHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateItemWithRequestPermission()
    {
        // Arrange
        const string description = "SOME_DESCRIPTION";
        var mockStoreItemService = Substitute.For<IStoreItemService>();
        var handler = GetHandler(mockStoreItemService: mockStoreItemService);

        // Act
        await handler.Handle(new(description), default);

        // Assert
        await mockStoreItemService.Received()
            .StoreAsync(
                Arg.Is<Item>(x => x.Description == description),
                Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccessResult()
    {
        // Arrange
        var mockStoreItemService = Substitute.For<IStoreItemService>();
        var handler = GetHandler(mockStoreItemService: mockStoreItemService);

        // Act
        var result = await handler.Handle(new(string.Empty), default);

        // Assert
        Assert.True(result.IsSuccess);
    }

    private static StoreItemHandler GetHandler(IStoreItemService? mockStoreItemService)
    {
        mockStoreItemService ??= Substitute.For<IStoreItemService>();

        var handler = new StoreItemHandler(mockStoreItemService);

        return handler;
    }
}