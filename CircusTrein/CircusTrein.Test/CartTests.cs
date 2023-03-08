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

        cart.TryAddAnimal(animal);

        Assert.NotEmpty(cart.AnimalList);
    }

    [Fact]
    public void CantAddAnimalToCartIfThereIsNoSpace()
    {
        Cart cart = new Cart();
        IAnimal animal = AG.GetHerbivore(5);
        cart.TryAddAnimal(animal);
        cart.TryAddAnimal(animal);

        Assert.Equal(0, cart.GetSpace());
    }
}