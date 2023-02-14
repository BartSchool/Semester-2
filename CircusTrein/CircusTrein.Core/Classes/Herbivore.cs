using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Herbivore : IAnimal
{
    public int size { get; private set; }

    public Herbivore(int size)
    {
        this.size = size;
    }

    public bool CanJoinCart(Cart cart)
    {
        if (cart.GetSpace() >= size)
            if (!CanBeEatenInCart(cart))
                return true;
        return false;
    }

    public bool CanBeEatenInCart(Cart cart)
    {
        foreach (Carnivore carnivore in cart.AnimalList.OfType<Carnivore>())
            if (carnivore.size >= size)
                return true;
        return false;
    }
}
