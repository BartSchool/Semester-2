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

        bool result = animal.CanJoinCart(cart);

        Assert.True(result);
    }
    [Fact]
    public void AnimalCantJoinCartIfThereIsntSpace()
    {
        IAnimal animal = AG.GetHerbivore(3);
        Cart cart = new Cart();
        cart.AddAnimal(AG.GetHerbivore(5));
        cart.AddAnimal(AG.GetHerbivore(5));

        bool result = animal.CanJoinCart(cart);

        Assert.False(result);
    }
    [Fact]
    public void CarnivoreCantJoinCartIfThereIsASmallerAnimal()
    {
        IAnimal animal = AG.GetCarnivore(5);
        Cart cart = new Cart();
        cart.AddAnimal(AG.GetHerbivore(3));

        bool result = animal.CanJoinCart(cart);

        Assert.False(result);
    }
    [Fact]
    public void CanCheckIfAnimalGetsEaten()
    {
        IAnimal animal = AG.GetCarnivore(1);
        Cart cart = new Cart();
        bool result1 = animal.CanBeEatenInCart(cart);
        cart.AddAnimal(AG.GetCarnivore(5));
        bool result2 = animal.CanBeEatenInCart(cart);

        Assert.False(result1);
        Assert.True(result2);
    }
    [Fact]
    public void CarnivoreCantJoinIfNoSpace()
    {
        Cart cart = new Cart();
        IAnimal animal = AG.GetCarnivore(3);
        cart.AddAnimal(AG.GetHerbivore(5));
        cart.AddAnimal(AG.GetHerbivore(5));

        bool result = animal.CanJoinCart(cart);

        Assert.False(result);
    }
    [Fact]
    public void HerbivoreCantJoinIfNoSpace()
    {
        Cart cart = new Cart();
        IAnimal animal = AG.GetHerbivore(5);
        cart.AddAnimal(AG.GetHerbivore(5));
        cart.AddAnimal(AG.GetCarnivore(3));

        bool result = animal.CanJoinCart(cart);

        Assert.False(result);
    }
}
