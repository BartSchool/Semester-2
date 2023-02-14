using CircusTrein.Core.Classes;
using CircusTrein.Core.Interfaces;

namespace CircusTrein.Test;

public class CartTests
{
    AnimalGenerator AG = new();

    [Fact]
    public void CanCreateCart()
    {
        Cart cart = new Cart();
        
        Assert.NotNull(cart);
    }

    [Fact]
    public void CanAddAnimalToCart()
    {
        Cart cart = new Cart();
        IAnimal animal = AG.GetCarnivore(3);

        cart.AddAnimal(animal);

        Assert.NotEmpty(cart.AnimalList);
    }

    [Fact]
    public void CantAddAnimalToCartIfThereIsNoSpace()
    {
        Cart cart = new Cart();
        IAnimal animal = AG.GetHerbivore(5);
        cart.AddAnimal(animal);
        cart.AddAnimal(animal);

        Assert.Equal(0, cart.GetSpace());
    }
}