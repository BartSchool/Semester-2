using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public class Herbivore : IHerbivore
{
    public int size { get; private set; }

    public Herbivore(int size)
    {
        this.size = size;
    }

    public bool CanJoinCollection(IAnimalCollection animalCollection)
    {
        if (!CanBeEatenInCollection(animalCollection))
            return true;
        return false;
    }

    public bool CanBeEatenInCollection(IAnimalCollection animalCollection)
    {
        foreach (ICarnivore carnivore in animalCollection.AnimalList.OfType<ICarnivore>())
            if (carnivore.size >= size)
                return true;
        return false;
    }
}
