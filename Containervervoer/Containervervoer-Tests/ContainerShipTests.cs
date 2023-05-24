namespace Containervervoer_Tests;

using Containervervoer_Core;

public class ContainerShipTests
{
    [Fact]
    public void Can_Add_Container_When_Place_Is_Empty()
    {
        // Arrange
        Container container = new Container(23);
        ContainerShip containerShip = new ContainerShip(3, 3, 3, 1000);

        // Act
        containerShip.AddContainer(container, 0, 0);

        // Assert
        Assert.Equal(container, containerShip.containers[0, 0, 0]);
    }

    [Fact]
    public void Throws_Exception_When_Place_Is_Full()
    {
        // Arrange
        Container container = new Container(20);
        ContainerShip containerShip = new ContainerShip(3, 3, 3, 1000);
        containerShip.AddContainer(container, 0, 0);
        containerShip.AddContainer(container, 0, 0);
        containerShip.AddContainer(container, 0, 0);

        // Act
        Action act = () => containerShip.AddContainer(container, 0, 0);

        // Assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("This place on the ship is allready full", exception.Message);
    }

    [Fact]
    public void Balance_Is_0_When_Ship_Is_Empty()
    {
        // Arrange
        ContainerShip containerShip = new ContainerShip(3, 3, 3, 1000);

        // Act
        int result = containerShip.CalculateBalance();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Balance_Is_Positive_When_Right_Is_Heavier()
    {
        // Arrange
        Container container = new Container(20);
        ContainerShip containerShip = new ContainerShip(3, 3, 3, 1000);
        containerShip.AddContainer(container, 0, 2);

        // Act
        int result = containerShip.CalculateBalance();

        // Assert
        Assert.Equal(24, result);
    }

    [Fact]
    public void Balance_Is_Negative_When_Left_Is_Heavier()
    {
        // Arrange
        Container container = new Container(20);
        ContainerShip containerShip = new ContainerShip(3, 3, 3, 1000);
        containerShip.AddContainer(container, 0, 0);

        // Act
        int result = containerShip.CalculateBalance();

        // Assert
        Assert.Equal(-24, result);
    }

    [Fact]
    public void Balance_Is_0_When_Left_And_Right_Has_Same_weight()
    {
        // Arrange
        Container container = new Container(20);
        ContainerShip containerShip = new ContainerShip(3, 3, 3, 1000);
        containerShip.AddContainer(container, 0, 0);
        containerShip.AddContainer(container, 0, 2);

        // Act
        int result = containerShip.CalculateBalance();

        // Assert
        Assert.Equal(0, result);
    }
}
