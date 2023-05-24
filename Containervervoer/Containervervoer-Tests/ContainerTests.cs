using Containervervoer_Core;

namespace Containervervoer_Tests;

public class ContainerTests
{
    [Fact]
    public void Throws_Exception_When_Cargoweight_Is_Negative()
    {
        // Arrange

        // Act
        Action act = () => new Container(-20);

        // Assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("Can't have cargo with a negative weight", exception.Message);
    }
}