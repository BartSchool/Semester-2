using CircusTrein.Core.Classes;

namespace CircusTrein.Test;

public class TrainTests
{
    AnimalGenerator AG = new();

    [Fact]
    public void Scenario1()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(0, 3, 2, 1, 0, 0));

        train.DistributeAnimals();

        Assert.Equal(2, train.cartList.Count);
    }

    [Fact]
    public void Scenario2()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(5, 2, 1, 1, 0, 0));

        train.DistributeAnimals();

        Assert.Equal(2, train.cartList.Count);
    }

    [Fact]
    public void Scenario3()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(1, 1, 1, 1, 1, 1));

        train.DistributeAnimals();

        Assert.Equal(4, train.cartList.Count);
    }
    [Fact]
    public void Scenario4()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(1, 5, 1, 2, 1, 1));

        train.DistributeAnimals();

        Assert.Equal(5, train.cartList.Count);
    }
    [Fact]
    public void Scenario5()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(1, 1, 2, 1, 0, 0));

        train.DistributeAnimals();

        Assert.Equal(2, train.cartList.Count);
    }
    [Fact]
    public void Scenario6()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(0, 2, 3, 3, 0, 0));

        train.DistributeAnimals();

        Assert.Equal(3, train.cartList.Count);
    }
    [Fact]
    public void Scenario7()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(0, 5, 6, 7, 3, 3));

        train.DistributeAnimals();

        Assert.Equal(13, train.cartList.Count);
    }
    [Fact]
    public void Scenario8()
    {
        Train train = new Train();
        train.AnimalCollection.AddAnimals(AG.getAnimals(4, 0, 2, 0, 3, 1));

        train.DistributeAnimals();

        Assert.Equal(5, train.cartList.Count);
    }
}
