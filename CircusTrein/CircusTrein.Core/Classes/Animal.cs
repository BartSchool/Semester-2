using CircusTrein.Core.Interfaces;

namespace CircusTrein.Core.Classes;

public abstract class Animal : IAnimal
{
    public abstract int size { get; set; }

    public bool CanBeEatenInCollection(List<IAnimal> animalList)
    {
        foreach (ICarnivore carnivore in animalList.OfType<ICarnivore>())
            if (carnivore.size >= size)
                return true;
        return false;
    }

    public abstract bool CanJoinCollection(List<IAnimal> animalList);
}
