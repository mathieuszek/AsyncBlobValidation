using File.Service.Commons;

namespace UnitTests.Commons;

public class PathGeneratorTests
{
    [Fact]
    public void GenerateDateTimePathGenerateDateTimePathUpToMinutes_ShouldReturnDateWithSlashes()
    {
        // Arrange
        var dateTime = new DateTime(2020, 1, 2, 3, 4, default);

        // Act
        var result = PathGenerator.GenerateDateTimePathUpToMinutes(dateTime);

        // Assert
        Assert.Equal("2020/01/02/03/04", result);
    }
}