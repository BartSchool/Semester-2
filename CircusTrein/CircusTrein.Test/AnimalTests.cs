using CircusTrein.Core.Classes;
using CircusTrein.Core.Interfaces;

namespace CircusTrein.Test;

public class AnimalTests
{
    AnimalGenerator AG = new();

    [Fact]
    public void CanCreateCarnivoreAsIAnimal()
    {
        IAnimal animal = AG.GetCarnivore(1);
        Assert.NotNull(animal);
    }
    [Fact]
    public void CanCreateHerbivoreAsIAnimal()
    {
        IAnimal animal = AG.GetHerbivore(1);
        Assert.NotNull(animal);
    }
    [Fact]
    public void AnimalCanJoinCartIfThereIsSpace()
    {
        IAnimal animal = AG.GetCarnivore(3);
        Cart cart = new Cart();

        bool result = animal.CanJoinCollection(cart.AnimalList);

        Assert.True(result);
    }
    [Fact]
    public void CarnivoreCantJoinCartIfThereIsASmallerAnimal()
    {
        IAnimal animal = AG.GetCarnivore(5);
        Cart cart = new Cart();
        cart.TryAddAnimal(AG.GetHerbivore(3));

        bool result = animal.CanJoinCollection(cart.AnimalList);

        Assert.False(result);
    }
    [Fact]
    public void CanCheckIfAnimalGetsEaten()
    {
        IAnimal animal = AG.GetCarnivore(1);
        Cart cart = new Cart();
        bool result1 = animal.CanBeEatenInCollection(cart.AnimalList);
        cart.TryAddAnimal(AG.GetCarnivore(5));
        bool result2 = animal.CanBeEatenInCollection(cart.AnimalList);

        Assert.False(result1);
        Assert.True(result2);
    }
}
