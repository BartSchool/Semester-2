using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Carnivore : IAnimal
{
    public int size { get; private set; }

    public Carnivore(int size)
    {
        this.size = size;
    }

    private bool CanEat(IAnimal animal)
    {
        if (animal.size <= size)
            return true;
        return false;
    }

    public bool CanJoinCart(Cart cart)
    {
        if (cart.GetSpace() >= size)
            if (!CanBeEatenInCart(cart))
            {
                foreach (IAnimal animal in cart.AnimalList)
                    if (CanEat(animal))
                        return false;
                return true;
            }
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
