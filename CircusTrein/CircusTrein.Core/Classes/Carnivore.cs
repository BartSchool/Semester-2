using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Carnivore : ICarnivore
{
    public int size { get; private set; }

    public Carnivore(int size)
    {
        this.size = size;
    }

    public bool CanEat(IAnimal animal)
    {
        if (animal.size <= size)
            return true;
        return false;
    }

    public bool CanJoinCollection(IAnimalCollection cart)
    {
        if (!CanBeEatenInCollection(cart))
        {
            foreach (IAnimal animal in cart.AnimalList)
                if (CanEat(animal))
                    return false;
            return true;
        }
        return false;
    }
    public bool CanBeEatenInCollection(IAnimalCollection cart)
    {
        foreach (ICarnivore carnivore in cart.AnimalList.OfType<ICarnivore>())
            if (carnivore.size >= size)
                return true;
        return false;
    }
}
